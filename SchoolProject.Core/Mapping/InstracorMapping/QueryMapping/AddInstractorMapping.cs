using AutoMapper;
using SchoolProject.Core.Feature.Instractor.Command.Models;
using SchoolProject.Core.Results;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.InstracorMapping
{
    public  partial class InstractorMap
    {

   public void AddInstracorMapping()
        {


            CreateMap<AddInstractorCommand, Instructor>()
           .ForMember(des => des.Image, op => op.Ignore())

           .ForMember(des => des.ENameAr, op => op.
            MapFrom(db => db.ENameAr))
             .ForMember(des => des.ENameEn, op => op.
            MapFrom(db => db.ENameEn));


        }

    }
    }

