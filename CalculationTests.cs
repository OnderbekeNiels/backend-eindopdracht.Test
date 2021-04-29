using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using backend_eindopdracht_keephealthy.Configuration;
using backend_eindopdracht_keephealthy.DTO;
using backend_eindopdracht_keephealthy.DTO.CustomAttributes;
using backend_eindopdracht_keephealthy.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace backend_eindopdracht.Test
{
    public class RegistrationRepositoryTets
    {

        public RegistrationRepositoryTets()
        {
        }

        // ! IsValidTimeString()

        [Theory]
        [InlineData("23:00")]
        [InlineData("23:30")]
        [InlineData("00:15")]
        [InlineData("23:59")]
        [InlineData("00:59")]
        public void IsValidTimeString_Should_Return_True(string hour)
        {
            Assert.True(CalculationService.IsValidTimeString(hour));
        }

        [Theory]
        [InlineData("24:00")]
        [InlineData("00:60")]
        [InlineData("24:60")]
        [InlineData("27:00")]
        public void IsValidTimeString_Should_Return_False(string hour)
        {
            Assert.False(CalculationService.IsValidTimeString(hour));
        }

        [Theory]
        [InlineData("0606")]
        [InlineData(":06")]
        [InlineData("00")]
        [InlineData("wrong")]
        public void IsValidTimeString_Should_Return_ArgumentEx(string hour)
        {
            Assert.Throws<ArgumentException>(() => CalculationService.IsValidTimeString(hour));
        }

        // ! Validation Attribute als unit test.

        // testing custom attributes (does not affect code coverage)

        [Theory]
        [InlineData("0606")]
        [InlineData(":06")]
        [InlineData("00")]
        [InlineData("wrong")]
        public void IsValidTimeString_Attribute_Should_Return_ArgumentEx(string hour)
        {
            ValidTimeStringAttribute attribute = new ValidTimeStringAttribute();
            Assert.False(attribute.IsValid(hour));
        }

        // ! GroupRegisrationsByDay()

        List<RegistrationDTO> registrations = new List<RegistrationDTO>() { new RegistrationDTO { RegistrationId = Guid.Parse("3be9f257-22a3-4b91-8aa4-9ec1a30a4ff1"), GoogleUserId = "qdVxjYLuvHQRJc5BhOcncgB5jJ43", Time = DateTime.Now, Value = 65, TopicId = Guid.Parse("48fb5b75-1094-4c13-a288-c571f9e23cb2") }, new RegistrationDTO { RegistrationId = Guid.Parse("c0708050-8d2e-4b5c-b161-7f46485cf8b8"), GoogleUserId = "qdVxjYLuvHQRJc5BhOcncgB5jJ43", Time = DateTime.Now.AddDays(1), Value = 60, TopicId = Guid.Parse("a700c9ae-58ab-44a2-a65e-b6227c69513c") }, new RegistrationDTO { RegistrationId = Guid.Parse("6f3f51bc-37b6-4b94-8fef-fba63aebe5c1"), GoogleUserId = "qdVxjYLuvHQRJc5BhOcncgB5jJ43", Time = DateTime.Now, Value = 60, TopicId = Guid.Parse("f8902f75-9058-48ba-8f88-bc7ce77896f5") } };

        [Fact]
        public void GroupRegisrationsByDay_Should_Return_2_Days()
        {
            List<List<RegistrationDTO>> groupedRegs = CalculationService.GroupRegisrationsByDay(registrations);
            Assert.Equal<int>(2, groupedRegs.Count);
        }

        // ! CalculateTotalValueOfGroupedRegistrations()

        [Fact]
        public void CalculateTotalValueOfGroupedRegistrations_Should_Return_125()
        {
            List<List<RegistrationDTO>> groupedRegistrations = new List<List<RegistrationDTO>>()
        {
             new List<RegistrationDTO>() {
                 new RegistrationDTO { RegistrationId = Guid.Parse("3be9f257-22a3-4b91-8aa4-9ec1a30a4ff1"),  GoogleUserId = "qdVxjYLuvHQRJc5BhOcncgB5jJ43", Time = DateTime.Now, Value = 65, TopicId = Guid.Parse("48fb5b75-1094-4c13-a288-c571f9e23cb2") },
                 new RegistrationDTO { RegistrationId = Guid.Parse("6f3f51bc-37b6-4b94-8fef-fba63aebe5c1"), GoogleUserId = "qdVxjYLuvHQRJc5BhOcncgB5jJ43", Time = DateTime.Now, Value = 60, TopicId = Guid.Parse("f8902f75-9058-48ba-8f88-bc7ce77896f5")}},
                 new List<RegistrationDTO>() {
            new RegistrationDTO { RegistrationId = Guid.Parse("c0708050-8d2e-4b5c-b161-7f46485cf8b8"), GoogleUserId = "qdVxjYLuvHQRJc5BhOcncgB5jJ43", Time = DateTime.Now.AddDays(1), Value = 60, TopicId = Guid.Parse("a700c9ae-58ab-44a2-a65e-b6227c69513c") }
                     }};
            List<RegistrationDayResultDTO> dayResults = CalculationService.CalculateTotalValueOfGroupedRegistrations(groupedRegistrations);
            Assert.Equal<double>(125, dayResults[0].Value);
        }

        [Fact]
        public void CalculateTotalValueOfGroupedRegistrations_Should_Return_0_Count()
        {
            List<List<RegistrationDTO>> groupedRegistrationsEmpty = new List<List<RegistrationDTO>>();
            List<RegistrationDayResultDTO> dayResults = CalculationService.CalculateTotalValueOfGroupedRegistrations(groupedRegistrationsEmpty);
            Assert.Equal<double>(0, dayResults.Count);
        }

    }
}
