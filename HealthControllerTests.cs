using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using backend_eindopdracht_keephealthy.DTO;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace backend_eindopdrachts.Test
{
    public class HealthControllerTests : IClassFixture<WebApplicationFactory<backend_eindopdracht_keephealthy.Startup>>
    {
        public HttpClient Client;

        public HealthControllerTests(WebApplicationFactory<backend_eindopdracht_keephealthy.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        // ! Integration tests

        // ? CREATE

        [Fact]
        public async Task Add_User_Shoud_Be_201()
        {
            var user = new GoogleUserDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43"
            };

            string json = JsonConvert.SerializeObject(user);

            var response = await Client.PostAsync("api/user/login", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Add_Water_Registration_Should_Be_201()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("226955be-d921-4f40-8e0c-1578a9170784"),
                Value = 0.25
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Add_Water_Registration_To_Big_Should_Be_400()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("226955be-d921-4f40-8e0c-1578a9170784"),
                Value = 51
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Water_Registration_To_Low_Should_Be_400()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("226955be-d921-4f40-8e0c-1578a9170784"),
                Value = -1
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Weight_Registration_Should_Be_201()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("20d37d1b-c129-481f-bab2-428f128ed03e"),
                Value = 65
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Add_Weight_Registration_To_Big_Should_Be_400()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("20d37d1b-c129-481f-bab2-428f128ed03e"),
                Value = 401
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Weight_Registration_To_Low_Should_Be_400()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("20d37d1b-c129-481f-bab2-428f128ed03e"),
                Value = -1
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Sleep_Registration_Should_Be_201()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0"),
                Value = 46464
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Add_Sleep_Registration_To_Big_Should_Be_400()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0"),
                Value = 86401
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Sleep_Registration_To_Low_Should_Be_400()
        {
            var registration = new RegistrationDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                TopicId = Guid.Parse("9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0"),
                Value = -1
            };

            string json = JsonConvert.SerializeObject(registration);

            var response = await Client.PostAsync("api/registration", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        // ! kan maar 1x getest worden

        // [Fact]
        // public async Task Add_Sleep_Setting_Should_Be_201()
        // {
        //     var user = new SleepSettingDTO()
        //     {
        //         GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
        //         SleepTime = "23:00", 
        //         WakeUpTime = "07:45"
        //     };

        //     string json = JsonConvert.SerializeObject(user);

        //     var response = await Client.PostAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
        //     response.StatusCode.Should().Be(HttpStatusCode.Created);
        // }

        [Fact]
        public async Task Add_Sleep_Setting_Without_WakeUpTime_Should_Be_400()
        {
            var sleepSetting = new SleepSettingDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                SleepTime = "23:00",
            };

            string json = JsonConvert.SerializeObject(sleepSetting);

            var response = await Client.PostAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Sleep_Setting_Without_SleepTime_Should_Be_400()
        {
            var sleepSetting = new SleepSettingDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                WakeUpTime = "07:00",
            };

            string json = JsonConvert.SerializeObject(sleepSetting);

            var response = await Client.PostAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Add_Sleep_Setting_Without_UserId_Should_Be_400()
        {
            var sleepSetting = new SleepSettingDTO()
            {
                SleepTime = "23:00",
                WakeUpTime = "07:00",
            };

            string json = JsonConvert.SerializeObject(sleepSetting);

            var response = await Client.PostAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        // ! Vragen waarom hij hier toch geen fout op geeft? Omdat het een bool is?

        // [Fact]
        // public async Task Add_Sleep_Setting_Without_SendNotifi_Should_Be_400()
        // {
        //     var user = new SleepSettingDTO()
        //     {
        //         GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
        //         SleepTime = "23:00", 
        //         WakeUpTime = "07:45"
        //     };

        //     string json = JsonConvert.SerializeObject(user);

        //     var response = await Client.PostAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
        //     response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        // }





        // ? READ

        [Fact]
        public async Task Get_Topics_Should_Be_Ok_And_Count_3()
        {
            var response = await Client.GetAsync("api/topics");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var topics = JsonConvert.DeserializeObject<List<TopicDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(topics.Count == 3);
        }

        [Fact]
        public async Task Get_Latest_Registration_From_User_From_Topic_Should_Be_Ok()
        {
            var response = await Client.GetAsync("api/registration/latest/9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Latest_Registration_From_Bad_UserId_From_Topic_Should_Be_204()
        {
            var response = await Client.GetAsync("api/registration/latest/9be26ee9-ef1c-4af0-b6ea-85a40efa6bf0/qdVxjYLu464sd774fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Get_Latest_Registration_From_User_From_No_Guid_Should_Be_400()
        {
            var response = await Client.GetAsync("api/registration/latest/noGuid/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Latest_Registrations_From_User_From_Topic_Should_Be_Ok()
        {
            var response = await Client.GetAsync("api/registrations/latest/9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var registrations = JsonConvert.DeserializeObject<List<RegistrationDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(registrations.Count > 0);
        }

        [Fact]
        public async Task Get_Latest_Registrations_From_Bad_UserId_From_Topic_Should_Be_204()
        {
            var response = await Client.GetAsync("api/registrations/latest/9be26ee9-ef1c-4af0-b6ea-85a40efa6bf0/qdVxjYLu464sd774fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Get_Latest_Registrations_From_User_From_No_Guid_Should_Be_400()
        {
            var response = await Client.GetAsync("api/registrations/latest/noGuid/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Latest_DayTotals_From_User_From_Topic_Should_Be_Ok()
        {
            var response = await Client.GetAsync("api/registrations/latest/daytotal/9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var registrations = JsonConvert.DeserializeObject<List<RegistrationDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(registrations.Count > 0);
        }

        [Fact]
        public async Task Get_Latest_DayTotals_From_Bad_UserId_From_Topic_Should_Be_204()
        {
            var response = await Client.GetAsync("api/registrations/latest/daytotal/9be26ee9-ef1c-4af0-b6ea-85a40efa6bf0/qdVxjYLu464sd774fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Get_Latest_DayTotals_From_User_From_No_Guid_Should_Be_400()
        {
            var response = await Client.GetAsync("api/registrations/latest/daytotal/noGuid/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Sleep_Settings_From_User_Should_Be_Ok()
        {
            var response = await Client.GetAsync("api/settings/sleepsetting/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Sleep_Settings_From_User_Should_Be_204()
        {
            var response = await Client.GetAsync("api/settings/sleepsetting/userwithnodata");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        // ? UPDATE

        [Fact]
        public async Task Update_Sleep_Settings_From_User_Should_Be_200()
        {

            var sleepSetting = new SleepSettingDTO()
            {
                SleepSettingId = Guid.Parse("fe396c4b-f7c7-4ac2-8f3e-08d909a9f2d2"),
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                SleepTime = "23:00",
                WakeUpTime = "07:00",
                SendNotifications = true
            };

            string json = JsonConvert.SerializeObject(sleepSetting);

            var response = await Client.PutAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_Sleep_Settings_From_User_Without_RegistrationId_Should_Be_500()
        {
            var sleepSetting = new SleepSettingDTO()
            {
                GoogleUserId = "qdVxjYLu464sd654fBhOcncgB5jJ43",
                SleepTime = "23:00",
                WakeUpTime = "07:00",
                SendNotifications = true
            };

            string json = JsonConvert.SerializeObject(sleepSetting);

            var response = await Client.PutAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        // ? DELETE

        [Fact]
        public async Task Delete_Latest_Registration_From_User_From_Topic_Should_Be_204()
        {
            var response = await Client.DeleteAsync("api/registration/latest/9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Delete_Latest_Registration_From_User_From_Topic_Should_Be_404()
        {
            var response = await Client.DeleteAsync("api/registration/latest/9be26ee9-ef1c-5555-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // ! Werkt eenmalig door 1 specifiek Id

        // [Fact]
        // public async Task Delete_Registration_From_User_With_RegistrationId_Should_Be_204()
        // {
        //     var response = await Client.DeleteAsync("api/registration/dccf51e1-90a8-4132-15ca-08d909ab4f76");
        //     response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        // }

        [Fact]
        public async Task Delete_Registration_From_User_With_RegistrationId_Should_Be_404()
        {
            var response = await Client.DeleteAsync("api/registration/dccf51e1-90a8-5555-15ca-08d909ab4f76");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_All_Registration_From_User_From_Topic_Should_Be_204()
        {
            var response = await Client.DeleteAsync("api/registration/9be26ee9-ef1c-4af0-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Delete_All_Registration_From_User_From_Topic_Should_Be_404()
        {
            var response = await Client.DeleteAsync("api/registration/9be26ee9-ef1c-5555-b6ea-82a40efa6bf0/qdVxjYLu464sd654fBhOcncgB5jJ43");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


    }
}