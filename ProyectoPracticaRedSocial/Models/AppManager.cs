using ProyectoPracticaRedSocial.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaRedSocial.Models
{
    internal class AppManager
    {
        public string AppTitle { get; set; }

        public ILog<string> log { get; set; }

        //Inyectamos la dependencia a traves del constructor
        public AppManager(ILog<string> logger) {

            log = logger;
            AppTitle = "administrador de redes sociales";
            SocialNetworks = new List<SocialNetwork>();
            SocialNetworkWithGroups = new List<SocialNetworkWithGroups>();
            InitializeSocialNetwork();
        }

        public void InitializeSocialNetwork()
        {
            SocialNetworks.Add(new SocialNetwork()
            {
                Name = "Twitter",
                Description = "Red social para escribir tus actividades",
                Users = new List<User>(),
                DateCreated = new DateTime(2010,10,20),
            });

            SocialNetworks.Add(new SocialNetwork()
            {
                Name = "Instagram",
                Description = "Red social para publicar tus fotos y videos",
                Users = new List<User>(),
                DateCreated = new DateTime(2009, 2, 12),
            });

            SocialNetworkWithGroups.Add(new SocialNetworkWithGroups()
            {
                Name = "Facebook",
                Description = "Red social para escribir tus pensamientos e interactuar con tus contactos",
                Users = new List<User>(),
                Groups = new List<string>() { "Programadores CSharp", "Amantes de la música", "Programadores Go" },
                DateCreated = new DateTime(2012, 1, 11),
            });

            log.SaveLog("InitializeSocialNetwork");
        }

        public List<SocialNetwork> SocialNetworks { get; set; }

        public List<SocialNetworkWithGroups> SocialNetworkWithGroups { get; set; }

        public string GetSocialNetworkInformation<T>(T socialNetwork)
        {

            if (socialNetwork == null) return "";

            StringBuilder stringBuilder = new StringBuilder();
            var socialNetworkItem = socialNetwork as SocialNetwork;

            stringBuilder.AppendLine($"Nombre: {socialNetworkItem.Name}");
            stringBuilder.AppendLine($"Descripción: {socialNetworkItem.Description}");
            stringBuilder.AppendLine($"Año de creación: {socialNetworkItem.DateCreated.Year}");

            if ( socialNetworkItem is SocialNetworkWithGroups)
            {
                var socialNetworkWithGroupsItem = socialNetwork as SocialNetworkWithGroups;
                stringBuilder.AppendLine($"Cantidad de Grupos: {socialNetworkWithGroupsItem.Groups.Count()}");
                stringBuilder.AppendLine($"Grupos: {string.Join(", ", socialNetworkWithGroupsItem.Groups)}");
                
            }
            log.SaveLog("GetSocialNetworkInformation");
            return stringBuilder.ToString();
        }

        public string GetSocialNetworkStats<T>(T socialNetwork)
        {

            if (socialNetwork == null) return "";

            StringBuilder stringBuilder = new StringBuilder();
            var socialNetworkItem = socialNetwork as SocialNetwork;

            try
            {
                stringBuilder.AppendLine($"Cantidad de usuarios: {socialNetworkItem.Users.Count}");
                stringBuilder.AppendLine($"Promedio de edad: {socialNetworkItem.Users.Average(p => p.Age)}");
                stringBuilder.AppendLine($"El usuario de mayor edad tiene: {socialNetworkItem.Users.Max(p => p.Age)}");
                stringBuilder.AppendLine($"El usuario de menor edad tiene: {socialNetworkItem.Users.Min(p => p.Age)}");
                stringBuilder.AppendLine($"Año de creación: {socialNetworkItem.DateCreated.Year}");

                if (socialNetworkItem is SocialNetworkWithGroups)
                {
                    var socialNetworkWithGroupsItem = socialNetwork as SocialNetworkWithGroups;
                    stringBuilder.AppendLine($"Cantidad de Grupos: {socialNetworkWithGroupsItem.Groups.Count}");
                    stringBuilder.AppendLine($"Grupos: {string.Join(", ", socialNetworkWithGroupsItem.Groups)}");

                }
            }
            catch (Exception ex)
            {

                log.SaveLog(ex.Message);
            }

            log.SaveLog("GetSocialNetworkStats");
            return stringBuilder.ToString();
        }
    }
}
