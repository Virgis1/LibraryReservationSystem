using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryReservationSystem.Business;

namespace LibraryReservationSystem.Data
{
    public static class BookRepository
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Title = "Netekę vilties", Author = "Colleen Hoover",
                    Year = 2025, Description = "„Nepaprasta istorija apie meilę ir išlikimą. Apie viltį ir išgijimą. Apie gyvenimą ir mirtį. Apie tai, kaip išgyvename tragediją ir randame atleidimą bei ramybę.“ – Tinklaraštis „Aestas Book Blog“"},
                new Book { Id=2, Title = "Skandaras ir griaučių prakeiksmas. 4 knyga", Author = "A.F. Steadman", Year = 2022, Description = "2022 m. išleista britų rašytojos knyga „Skandaras ir vienaragių vagis“ sulaukė milžiniško populiarumo. 2023 m. pasirodė antroji knyga „Skandaras ir raitelio šmėkla“, 2024 m. – „Skandaras ir chaoso išbandymai“." },
                new Book { Id = 3, Title = "Nepaleisti 13. Tomeno vaikinai", Author = "Chloe Walsh", Year = 2025, Description = "Įspūdinga ir nepamirštama meilės istorija, prasidėjusi knygoje „Pargriauti 13“, toliau plėtojama bestselerių autorės ir „Tik Tok“ sensacijos Chloe Walsh antrojoje serijos knygoje „Nepaleisti 13“." },
                new Book { Id = 4, Title = "Keturi susitarimai. Toltekų išminties knyga", Author = "Don Miguel Ruiz", Year = 2024, Description = "Remdamasis senovės toltekų išmintimi, autorius atskleidžia keturias paprastas, tačiau galingas gyvenimo taisykles, kurios gali padėti išsilaisvinti nuo mus ribojančių įsitikinimų ir minčių spąstų, siekiant tikros vidinės" },
                new Book { Id = 5, Title = "SKURDO VAIKAS", Author = "Katriona O’Sullivan", Year = 2025, Description = "Stulbinamas asmeninis liudijimas, papasakotas šiltai, atvirai ir su empatija. Knyga, kuri gali pakeisti visuomenę, o kartu ir mus pačius.Stulbinamas asmeninis liudijimas, papasakotas šiltai, atvirai ir su empatija." },
                new Book { Id = 6, Title = "PENKIOS MEILĖS KALBOS", Author = "Gary Chapman", Year = 2022, Description = "Pagrindinis žmogaus emocinis poreikis yra jaustis mylimam. Dėl meilės mes įkopiame į viršukalnes, perplaukiame jūras, pereiname dykumas ir ištveriame didžiausius sunkumus." },
                new Book { Id = 7, Title = "Prezidentas Gitanas Nausėda: iš arti", Author = "Laima Lavaste", Year = 2025, Description= "Išskirtinė galimybė pasinerti į Lietuvos Respublikos Prezidento gyvenimą per jo asmenines istorijas ir atviras įžvalgas iš pirmosios kadencijos." },
                new Book { Id = 8, Title = "LEBRONAS", Author = "Jeff Benedict", Year = 2025, Description = "NEW YORK TIMES BESTSELERIS Bestselerių Dynasty ir Tiger Woods autoriaus „autoritetinga... fantastiška“ (Sports Illustrated) krepšinio superžvaigždės LeBrono Jameso biografija, paremta trejus metus trukusiai" }
            };
        }
    }
}