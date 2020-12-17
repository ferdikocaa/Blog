using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;

namespace BlogApplication.Dto
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ArticleDto, ArticleDto>();
        }
    }
}
