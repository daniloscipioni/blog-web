using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogWeb.Models;
using BlogWeb.ViewModels;

namespace BlogWeb.App_Start
{
    public class AutoMapperConfig
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Post, PostModel>();

            Mapper.CreateMap<PostModel, Post>()
                .ForMember(post => post.Autor, opcoes =>{             
                                                            opcoes.MapFrom(m => new Usuario() { Id = m.AutorId });
                                                            opcoes.Condition(m => m.AutorId > 0);
                                                        }
                );

            Mapper.CreateMap<int, Tag>()
                .ConvertUsing(id => new Tag() { Id = id });

            Mapper.CreateMap<Tag, int>()
                .ConvertUsing(tag => tag.Id);
        
        }
    }
}