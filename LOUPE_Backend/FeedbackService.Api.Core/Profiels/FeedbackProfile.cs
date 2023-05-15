using AutoMapper;
using FeedbackService.API.Core.Viewmodels;
using FeedbackService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Api.Core.Profiels
{
    public class FeedbackProfile: Profile
    {
        public FeedbackProfile()
        {
            CreateMap<Feedback, FeedbackViewmodel>().ReverseMap();
        }

    }
}
