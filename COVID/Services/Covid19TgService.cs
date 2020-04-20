using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using COVID.Controls;
using COVID.Models;
using Xamarin.Essentials;

namespace COVID.Services
{
    public static class Covid19TgService
    {
        public static InfosCovid InfosCovid{get;set;}
        public static Details InfoduJour {get{ return InfosCovid.Details.FirstOrDefault();}} 
        public static void AppelNumeroVert()
        {
             PhoneDialer.Open(Covid19TgService.NumeroVert);
        }
        public static string NumeroVert{get;set;}="111";


    }
}
