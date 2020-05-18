using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.HelpDesk.Organizations
{
    public class OrganizationAppServiceTests : HelpDeskApplicationTestBase
    {
        private readonly IOrganizationAppService _organizationAppService;
        private readonly IRepository<Organization, Guid> _organizationRepository;

        public OrganizationAppServiceTests()
        {
            _organizationAppService = GetRequiredService<IOrganizationAppService>();
            _organizationRepository = GetRequiredService<IRepository<Organization, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _organizationAppService.GetListAsync(new GetOrganizationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("8895847e-95d9-4f87-bbaa-41a03fe5cfa2")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("357aa2d1-38e3-45f5-b495-e75e747f4cc6")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _organizationAppService.GetAsync(Guid.Parse("8895847e-95d9-4f87-bbaa-41a03fe5cfa2"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("8895847e-95d9-4f87-bbaa-41a03fe5cfa2"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new OrganizationCreateDto
            {
                Name = "c37124702fc14b5293bae3a020d051b8078807b857174ed1b2",
                Number = "1ccb4c5444bd48a78f7f903dd56b0f3bcf3751962c004759aa",
                Street = "8935e6ce84c84b9b89cfa29ea6193f315200ff99556d4efda0bb58b3a0d6d5cbeb71ba5d4a154b37ad1ce29628f2dc7c610a",
                City = "d1ac7920943247f0aa5570927598bc86a141de58745e4500b1",
                State = "ea752b0dc1694c23bde29d648f8881078308da1d21ae4885bb",
                Zipcode = "2bcafc4f66d14bb",
                Phone = "6593a25345e6400",
                Fax = "8cd71e5187e648c",
                Notes = "3240808e7b754ac3a015e345242b1a093e952aae84094f4d8df14f66c11f87c23ccb05a58b6545cca855e6446a95340df296feb026b44d589a0a2ce4dd3c22e679c659d60e5b4173ba2425296bc74118829a9dd6c6d14ef5bdcf8c4b7333aff73c1e4369620f4e76816d9b92a2bb9f7479914ab2ec5147f69cbd92f6ef47e66603ff1aa4eed747d7bee78a4f60cdca41d1cf85b111b0472390938167b951c83a64d7ca538fcd47b990f21754ef6111ae85ee4ff63a3242c0a8476967644d8abdf24f4c4449df44c8837cb3fecf7fbf6735703ab8b5e2417a832a3e34d84213be5ebc0413abd84bddb3a78787bea4a7b6bb97a00124984183bb153f4579b507b2fdafa5c2f1414511b3b8a2070e4de1d3faba53d1e6994951a60322123bd0170a4b0b7c06677048a4b4ebce92fe7ffc257e299e621abd40d3aff013bca07ee93c6f25da85d1354535a1a781d4258864136646a76d8637469889c37f37302a2a9e737518dc15414c549fcc97e96e7507a4038635fbed41462a9550ba2874a17533483f97370bf243f786a9453f2a1f18c6e088e9bb3e754059aa82be440336dab1c615f5b21d074053a6086f8849998803ff8c366b2fc141e9b295b4cb3774f508f3900f0d929841318c4f258befaeaee2dcc8adcf6e1143b7afdf8469e1ce39c923809aa2817f41a7ba3f94c7706a0030ddaf9aaba1ea4990a62b90c071d28f15"
            };

            // Act
            var serviceResult = await _organizationAppService.CreateAsync(input);

            // Assert
            var result = await _organizationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("c37124702fc14b5293bae3a020d051b8078807b857174ed1b2");
            result.Number.ShouldBe("1ccb4c5444bd48a78f7f903dd56b0f3bcf3751962c004759aa");
            result.Street.ShouldBe("8935e6ce84c84b9b89cfa29ea6193f315200ff99556d4efda0bb58b3a0d6d5cbeb71ba5d4a154b37ad1ce29628f2dc7c610a");
            result.City.ShouldBe("d1ac7920943247f0aa5570927598bc86a141de58745e4500b1");
            result.State.ShouldBe("ea752b0dc1694c23bde29d648f8881078308da1d21ae4885bb");
            result.Zipcode.ShouldBe("2bcafc4f66d14bb");
            result.Phone.ShouldBe("6593a25345e6400");
            result.Fax.ShouldBe("8cd71e5187e648c");
            result.Notes.ShouldBe("3240808e7b754ac3a015e345242b1a093e952aae84094f4d8df14f66c11f87c23ccb05a58b6545cca855e6446a95340df296feb026b44d589a0a2ce4dd3c22e679c659d60e5b4173ba2425296bc74118829a9dd6c6d14ef5bdcf8c4b7333aff73c1e4369620f4e76816d9b92a2bb9f7479914ab2ec5147f69cbd92f6ef47e66603ff1aa4eed747d7bee78a4f60cdca41d1cf85b111b0472390938167b951c83a64d7ca538fcd47b990f21754ef6111ae85ee4ff63a3242c0a8476967644d8abdf24f4c4449df44c8837cb3fecf7fbf6735703ab8b5e2417a832a3e34d84213be5ebc0413abd84bddb3a78787bea4a7b6bb97a00124984183bb153f4579b507b2fdafa5c2f1414511b3b8a2070e4de1d3faba53d1e6994951a60322123bd0170a4b0b7c06677048a4b4ebce92fe7ffc257e299e621abd40d3aff013bca07ee93c6f25da85d1354535a1a781d4258864136646a76d8637469889c37f37302a2a9e737518dc15414c549fcc97e96e7507a4038635fbed41462a9550ba2874a17533483f97370bf243f786a9453f2a1f18c6e088e9bb3e754059aa82be440336dab1c615f5b21d074053a6086f8849998803ff8c366b2fc141e9b295b4cb3774f508f3900f0d929841318c4f258befaeaee2dcc8adcf6e1143b7afdf8469e1ce39c923809aa2817f41a7ba3f94c7706a0030ddaf9aaba1ea4990a62b90c071d28f15");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new OrganizationUpdateDto()
            {
                Name = "966e736b2542492b9f98691be10a4e1ea6bc990f5c9a4bee89",
                Number = "732d0cd488ba4d74a5982b7c1d43de29c2d9c3d8de084207ac",
                Street = "afe59b931a974badbb9d2d21927723c57098bed9f93d4eaabe79418ea581958bdc593729b8a34a1dbf5b34cb38b1622a4bd4",
                City = "6256d63565904f5684897fe3876166b84c01115949724fe1be",
                State = "21d588243dac47588dbde23634da56ab09c02af57ca844f4ac",
                Zipcode = "92b61d2b93cb429",
                Phone = "6bf3d3988b50486",
                Fax = "520c8a930766469",
                Notes = "9a04963251c444af9fbaaed89cf8ca3bbbb1c48c1b6744c9a5183d373e26d975c832eb838d2040a489136b111e1b3ee96f3561155a1c45c1bf2a014b0c8068017eba14faab764074a300d271e0c1d52c9ee9bbf28f184955823816b4c71219c98a25fb1d2d504606a09d11c377ffe17b45e1fd062ae04888937e536499162704d47f690d891f4bb3a0d96b0936bf24b003db136365c54d7c82c397e8f2532e6bc3d4fd94f80a4a52bf3ca43df673c76f44079dd975db4caa866a120bf097585d9b79f5b287924b769285ab2b5777b5b899ac1d4eb9b647fc86eb2c7105b3b01450975f3de3a749adb8b0fd222acf5b48a806203c4a0c469387efdf5bef1ceb4c29c12dd3a6e0430e9d3562e8fd27fc32e2d6c1a7d0324bf3b5c205ee2edbdf4c7193457114a04d7889970dd9ce09709ffed579fbc3fa48fea91877874760e92b013df9f02d8743e2afeaea4ef76cbdeeb11101d1b9d34cd2b7cff2029d0671b5ca79569580fa4a21a69b41a316bb1bce47e8c6d2e2f54b1ba0722ba4d6bba7c3baa78b10382e402683fee60e645dbcb4a753674c3e714982b2d858c19313ad38adea35838b9b40e280a6333b57a31aa55d55c7623afe4748ac1153169b5221f9cd9010d87d41451a853d99dc20755be237a4dbbd38f548ea91674ce3c6a9b420bb1c8c399bd44caabf6d62c98832e24e354d7bf337a843e585244dc6d74ceab8"
            };

            // Act
            var serviceResult = await _organizationAppService.UpdateAsync(Guid.Parse("8895847e-95d9-4f87-bbaa-41a03fe5cfa2"), input);

            // Assert
            var result = await _organizationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("966e736b2542492b9f98691be10a4e1ea6bc990f5c9a4bee89");
            result.Number.ShouldBe("732d0cd488ba4d74a5982b7c1d43de29c2d9c3d8de084207ac");
            result.Street.ShouldBe("afe59b931a974badbb9d2d21927723c57098bed9f93d4eaabe79418ea581958bdc593729b8a34a1dbf5b34cb38b1622a4bd4");
            result.City.ShouldBe("6256d63565904f5684897fe3876166b84c01115949724fe1be");
            result.State.ShouldBe("21d588243dac47588dbde23634da56ab09c02af57ca844f4ac");
            result.Zipcode.ShouldBe("92b61d2b93cb429");
            result.Phone.ShouldBe("6bf3d3988b50486");
            result.Fax.ShouldBe("520c8a930766469");
            result.Notes.ShouldBe("9a04963251c444af9fbaaed89cf8ca3bbbb1c48c1b6744c9a5183d373e26d975c832eb838d2040a489136b111e1b3ee96f3561155a1c45c1bf2a014b0c8068017eba14faab764074a300d271e0c1d52c9ee9bbf28f184955823816b4c71219c98a25fb1d2d504606a09d11c377ffe17b45e1fd062ae04888937e536499162704d47f690d891f4bb3a0d96b0936bf24b003db136365c54d7c82c397e8f2532e6bc3d4fd94f80a4a52bf3ca43df673c76f44079dd975db4caa866a120bf097585d9b79f5b287924b769285ab2b5777b5b899ac1d4eb9b647fc86eb2c7105b3b01450975f3de3a749adb8b0fd222acf5b48a806203c4a0c469387efdf5bef1ceb4c29c12dd3a6e0430e9d3562e8fd27fc32e2d6c1a7d0324bf3b5c205ee2edbdf4c7193457114a04d7889970dd9ce09709ffed579fbc3fa48fea91877874760e92b013df9f02d8743e2afeaea4ef76cbdeeb11101d1b9d34cd2b7cff2029d0671b5ca79569580fa4a21a69b41a316bb1bce47e8c6d2e2f54b1ba0722ba4d6bba7c3baa78b10382e402683fee60e645dbcb4a753674c3e714982b2d858c19313ad38adea35838b9b40e280a6333b57a31aa55d55c7623afe4748ac1153169b5221f9cd9010d87d41451a853d99dc20755be237a4dbbd38f548ea91674ce3c6a9b420bb1c8c399bd44caabf6d62c98832e24e354d7bf337a843e585244dc6d74ceab8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _organizationAppService.DeleteAsync(Guid.Parse("d23b946e-4d38-458b-8e7f-ceff522131f8"));

            // Assert
            var result = await _organizationRepository.FindAsync(c => c.Id == Guid.Parse("d23b946e-4d38-458b-8e7f-ceff522131f8"));

            result.ShouldBeNull();
        }
    }
}