$(function () {

        
        

    var l = abp.localization.getResource("HelpDesk");
	
	var organizationService = window.acme.helpDesk.organizations.organization;
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Organizations/CreateModal",
        scriptUrl: "/Pages/Organizations/createModal.js",
        modalClass: "organizationCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Organizations/EditModal",
        scriptUrl: "/Pages/Organizations/editModal.js",
        modalClass: "organizationEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),	
            name: $("#NameFilter").val(),
			number: $("#NumberFilter").val(),
			street: $("#StreetFilter").val(),
			city: $("#CityFilter").val(),
			state: $("#StateFilter").val(),
			zipcode: $("#ZipcodeFilter").val(),
			phone: $("#PhoneFilter").val(),
			fax: $("#FaxFilter").val(),
			notes: $("#NotesFilter").val()
        };
    };
	
    var dataTable = $("#OrganizationsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(organizationService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('HelpDesk.Organizations.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('HelpDesk.Organizations.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    organizationService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "name" }
,			{ data: "number" }
,			{ data: "street" }
,			{ data: "city" }
,			{ data: "state" }
,			{ data: "zipcode" }
,			{ data: "phone" }
,			{ data: "fax" }
,			{ data: "notes" }

            
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewOrganizationButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchButton").click(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $('#FilterText').keypress(function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });
	
    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
});