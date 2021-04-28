using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using backend_eindopdracht_keephealthy.Configuration;
using backend_eindopdracht_keephealthy.DTO;
using backend_eindopdracht_keephealthy.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace backend_eindopdrachts.Test
{
    public class HealthControllerTests : IClassFixture<WebApplicationFactory<backend_eindopdracht_keephealthy.Startup>>
    {
        public HttpClient Client;

        private string USER_ID_REAL = "qdVxjYLu464sd654fBhOcncgB5jJ43";

        private string USER_ID_FAKE = "fake-id";

        private string TOPIC_ID_FAKE = "20d37d1b-c129-5555-bab2-428f128ed03e";

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
                GoogleUserId = USER_ID_REAL
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Water_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Water_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Water_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Weight_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Weight_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Weight_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Sleep_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Sleep_TopicId),
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
                GoogleUserId = USER_ID_REAL,
                TopicId = Guid.Parse(StaticTopics.Sleep_TopicId),
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
        //         GoogleUserId = USER_ID_REAL,
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
                GoogleUserId = USER_ID_REAL,
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
                GoogleUserId = USER_ID_REAL,
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
        //         GoogleUserId = USER_ID_REAL,
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
            var response = await Client.GetAsync($"api/registration/latest/{StaticTopics.Sleep_TopicId}/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Latest_Registration_From_Bad_UserId_From_Topic_Should_Be_204()
        {
            var response = await Client.GetAsync($"api/registration/latest/{StaticTopics.Sleep_TopicId}/{USER_ID_FAKE}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Get_Latest_Registration_From_User_From_No_Guid_Should_Be_400()
        {
            var response = await Client.GetAsync($"api/registration/latest/NO_GUID/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Latest_Registrations_From_User_From_Topic_Should_Be_Ok()
        {
            var response = await Client.GetAsync($"api/registrations/latest/{StaticTopics.Sleep_TopicId}/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var registrations = JsonConvert.DeserializeObject<List<RegistrationDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(registrations.Count > 0);
        }

        [Fact]
        public async Task Get_Latest_Registrations_From_Bad_UserId_From_Topic_Should_Be_204()
        {
            var response = await Client.GetAsync($"api/registrations/latest/{StaticTopics.Sleep_TopicId}/{USER_ID_FAKE}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Get_Latest_Registrations_From_User_From_No_Guid_Should_Be_400()
        {
            var response = await Client.GetAsync($"api/registrations/latest/NO_GUID/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Latest_DayTotals_From_User_From_Topic_Should_Be_Ok()
        {
            var response = await Client.GetAsync($"api/registrations/latest/daytotal/{StaticTopics.Sleep_TopicId}/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var registrations = JsonConvert.DeserializeObject<List<RegistrationDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(registrations.Count > 0);
        }

        [Fact]
        public async Task Get_Latest_DayTotals_From_Bad_UserId_From_Topic_Should_Be_204()
        {
            var response = await Client.GetAsync($"api/registrations/latest/daytotal/{StaticTopics.Sleep_TopicId}/{USER_ID_FAKE}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Get_Latest_DayTotals_From_User_From_No_Guid_Should_Be_400()
        {
            var response = await Client.GetAsync($"api/registrations/latest/daytotal/NO_GUID/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Sleep_Settings_From_User_Should_Be_Ok()
        {
            var response = await Client.GetAsync($"api/settings/sleepsetting/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Sleep_Settings_From_User_Should_Be_204()
        {
            var response = await Client.GetAsync($"api/settings/sleepsetting/{USER_ID_FAKE}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        // ? UPDATE

        // ! Kan pas getest worden wanneer er een registratie is met een bepaald Id

        // [Fact]
        // public async Task Update_Sleep_Settings_From_User_Should_Be_200()
        // {

        //     var sleepSetting = new SleepSettingDTO()
        //     {
        //         SleepSettingId = Guid.Parse("fe396c4b-f7c7-4ac2-8f3e-08d909a9f2d2"),
        //         GoogleUserId = USER_ID_REAL,
        //         SleepTime = "23:00",
        //         WakeUpTime = "07:00",
        //         SendNotifications = true
        //     };

        //     string json = JsonConvert.SerializeObject(sleepSetting);

        //     var response = await Client.PutAsync("api/settings/sleepsetting", new StringContent(json, Encoding.UTF8, "application/json"));
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        [Fact]
        public async Task Update_Sleep_Settings_From_User_Without_RegistrationId_Should_Be_500()
        {
            var sleepSetting = new SleepSettingDTO()
            {
                GoogleUserId = USER_ID_REAL,
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
            var response = await Client.DeleteAsync($"api/registration/latest/{StaticTopics.Sleep_TopicId}/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        // with wrong topic id
        public async Task Delete_Latest_Registration_From_User_From_Topic_Should_Be_404()
        {
            var response = await Client.DeleteAsync($"api/registration/latest/{TOPIC_ID_FAKE}/{USER_ID_REAL}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // //! Werkt eenmalig door 1 specifiek Id

        // [Fact]
        // public async Task Delete_Registration_From_User_With_RegistrationId_Should_Be_204()
        // {
        //     var response = await Client.DeleteAsync("api/registration/02fade1d-c0bb-4f09-ad27-08d908d7e3f5");
        //     response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        // }

        // [Fact]
        // public async Task Delete_Registration_From_User_With_RegistrationId_Should_Be_404()
        // {
        //     // user doesnt have any registration from this topic
        //     var response = await Client.DeleteAsync("api/registration/dccf51e1-90a8-5555-15ca-08d909ab4f76");
        //     response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        // }

        // [Fact]
        // public async Task Delete_All_Registration_From_User_From_Topic_Should_Be_204()
        // {
        //     var response = await Client.DeleteAsync($"api/registration/{StaticTopics.Sleep_TopicId}/{USER_ID_REAL}");
        //     response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        // }

        // [Fact]
        // public async Task Delete_All_Registration_From_User_From_Topic_Should_Be_404()
        // {
        //     // user doesnt have any registrations from this topic
        //     var response = await Client.DeleteAsync($"api/registration/{TOPIC_ID_FAKE}/{USER_ID_REAL}");
        //     response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        // }

        // ! Unit tests

        // [Fact]
        // public async Task Get_Registrations_DayTotals_Should_Count_1()
        // {
        //     List<RegistrationDayResultDTO> registrations = await _registrationService.GetLatestRegistrationsDayTotalByTopic(Guid.Parse(StaticTopics.Water_TopicId), "unitTestId-54564646");
        //     Assert.Equal<int>(1,registrations.Count);
        // }

        // [Fact]
        // public async Task Get_Registrations_DayTotals_Should_Be_0_75()
        // {
        //     List<RegistrationDayResultDTO> registrations = await _registrationService.GetLatestRegistrationsDayTotalByTopic(Guid.Parse(StaticTopics.Water_TopicId), "unitTestId-54564646");
        //     Assert.Equal<double>(0.75, registrations[0].Value);
        // }

    }
}
