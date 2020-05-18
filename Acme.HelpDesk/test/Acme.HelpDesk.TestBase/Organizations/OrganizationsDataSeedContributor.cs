using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Acme.HelpDesk.Organizations;

namespace Acme.HelpDesk.Organizations
{
    public class OrganizationsDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsDataSeedContributor(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _organizationRepository.InsertAsync(new Organization
            (
                id: Guid.Parse("8895847e-95d9-4f87-bbaa-41a03fe5cfa2"),
                name: "a7793eb9679c404cb4db842b58e69cae63d542710c564f7c8e",
                number: "06e68054dce9411e92411a85e979176255a9f840e32a497481",
                street: "00321cb4efea4fa9afadaa1dbec44a044a6f6043fc3d4949b891e468e504ec25788cbb6d025742279f4f93c2504d43149af8",
                city: "41906aee792f49989fceeb57f84dcd34031e140b90dd4cfdbe",
                state: "68cc9eef4df84dda843334307fd1909d40abf0ce37854a0880",
                zipcode: "57d6240d4c2a475",
                phone: "867605bcd85844a",
                fax: "9e1b016b0c3d4da",
                notes: "4bd807764aba4174a040103dea5b737e5c488d3bbf29445a82eb2645faddbca6ab517cfbfc904673b4d126ed61bca7911718137d29ac4b8d8bac0fba290206cd0b318e005b6c42ceb96f5d41ef6478854ad02a0778304be3bba6d15274e64081c7e5c5da8d5e4791be18284ded7dcaed4121d01bdbfb47f7a94573f45271dd6df0fd5f55e99647948ae4feabee98d0c1bdaa14c3a9c742a88a6a0ce2e4198a749a3779075ae4426ba2d1457ad27afb58edcd2fda4a3a40479ea510a23f610bb1fe4f13a21b544b66af78603f1d7057b09310ce5a64d145d5accb6bc9bf49cd27d6de272da49644cf846976f1ad0bd1b5376fffba711a410b825bf7f4b97d3ef1b72252aa9ca64dd5958aac2afc1cc3e36f08db317eaf415185e728355cb32fcf1a534544230a42d693b8dc77510bcfa6cafc1d9cd9624e80ae450badd1f4f928ab6c1fd310644ea9b6db1f4a6334e79141c7e44cdebc4c359095f74622f951ee4e1b8dd3d3bf47f79c3b2cf42d45601a0c883d5af8d64c7ab02d7291e2285d94d5df6207e4324d5ea1b03f2065674753cf845c4fbaa54269951ce3e01d5bc8d7d19ba03e34b042e8a3a1dffb2144794b738b9cb3ed8145dabf27149eae68b36f5c6b186e80f1413fbbbfeadd4e6e1305d784293dd12045ad8ad7e48eb2b084b16773fcd482ed48f6a7afcfdffc682045d144f72cfaa349c58e79eb1eed6d1591"
            ));

            await _organizationRepository.InsertAsync(new Organization
            (
                id: Guid.Parse("357aa2d1-38e3-45f5-b495-e75e747f4cc6"),
                name: "7e7536b841ea44d69a1ad5a2e203f7100106eaac40e443bf8e",
                number: "82a2bf77514041adbab190231f08feb84e7819dc7c6c46b3a2",
                street: "f18b46c259ca41caa51732730622fd4945620a69520b4a3aa82d946e8d173d5e6d818976d83b46d29c6b801a1716d64d1ce3",
                city: "dbed476ec5ad4d21b2acdcae73e58512443ed16145dc4cbb8b",
                state: "a15a36e6181948e399e1020c718eb1be1fd9c559405346c2b6",
                zipcode: "52e492c1e68e4e6",
                phone: "4373169514d549a",
                fax: "353c3df0508a4f7",
                notes: "26e7bc7a20f945798cf8fb0b8fc28da7ab1c729bb8774a7d8da018d7edf852fc75f30a3de12d4535862b8b9f8861b378358814a66aa844149f42c4040e583efc35f5a39087594b388669157a2fe68aa711c8548431ec4e54bb89bb9559e08b0981cee07727084706a0efcbead665e08d7ed0388f19d44fd7bfec9e98ce199bc2c326cef3f4ec4b9da114e93b3af78eebb24ebb0e84594d15a11634dd373c1f4e0139680c81c84d1a8d3521cfa4ae80b77cec01b28b444fd0940cf6328ce2263dd23660908c7a4d17ac79a1e7ae676fededfe1736084642c1ac1e622be22242e293bd172edbec49c1953c9be5ebd7a436ff195c67f0484e6bbb565f6421a6bf86fdac2c358e394e5eb297c024a2534efdcdc8a646e2ef44518c3beba633c21f48df47c6fcb97844fdadc9ff17221677f29ae2533c9f7a4a1baaf62b32693ed5feba6ec85c3ee9492a8676ecc329014193945d46d1c1e44d1aa314cfdfec745bb6695769178cf74c9e81f3d79aec7ba8b11109a46c69464e51bac605e0924f69859f34d6963a9e4eff9b845be781187de77f6b1896a5ac4544ba1974085fa88807abf65a89de9343aab7c4b99536053cded5689cedd6444607a8001d60d4374692c0c03e49a6e74e9d96a55efa8290f6860ed48e8e74874f3f9f82c7009979cc2dd5dc6381a0fb4bb5b023bac2786732dd6a1b89d04ac448c6b9f8fdbced5c09f4"
            ));
        }
    }
}