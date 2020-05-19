$(function () {

        
        

    var l = abp.localization.getResource("HelpDesk");
	
	var tagService = window.acme.helpDesk.tags.tag;
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Tags/CreateModal",
        scriptUrl: "/Pages/Tags/createModal.js",
        modalClass: "tagCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Tags/EditModal",
        scriptUrl: "/Pages/Tags/editModal.js",
        modalClass: "tagEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),	
            name: $("#NameFilter").val()
        };
    };
	
    var dataTable = $("#TagsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(tagService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('HelpDesk.Tags.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('HelpDesk.Tags.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    tagService.delete(data.record.id)
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

            
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewTagButton").click(function (e) {
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