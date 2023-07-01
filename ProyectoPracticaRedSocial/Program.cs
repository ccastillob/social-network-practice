// See https://aka.ms/new-console-template for more information

using ProyectoPracticaRedSocial.Models;
using ProyectoPracticaRedSocial.Utilities.Log;

// Le pasamos la implementación del Log por medio del constructor
var app = new AppManager(new LogJson());

Console.WriteLine($"Bienvenido al {app.AppTitle}");
bool keepGoingBucle = true;

while (keepGoingBucle)
{
    Console.WriteLine("Estas son las redes sociales actuales");

    // Concat -> sirve para agrupar colecciones
    foreach (var item in app.SocialNetworks.Concat(app.SocialNetworkWithGroups))
    {
        Console.WriteLine(item.Name);
    }

    Console.WriteLine("Por favor ingresa la red social a la cual deseas ingresar");
    string socialNetworkName = Console.ReadLine();

    var socialNetworkSelected = app.SocialNetworks.FirstOrDefault(p => p.Name.ToLower() == socialNetworkName.ToLower());

    Console.Write(app.GetSocialNetworkInformation(socialNetworkSelected));

    var socialNetworkWithGroupsSelected = app.SocialNetworkWithGroups.FirstOrDefault(p => p.Name.ToLower() == socialNetworkName.ToLower());

    Console.Write(app.GetSocialNetworkInformation(socialNetworkWithGroupsSelected));

    Console.WriteLine("");

    if(socialNetworkWithGroupsSelected != null )
    {
        Console.WriteLine($"Desea agregar un nuevo grupo a {socialNetworkWithGroupsSelected.Name.ToUpper()}");
        Console.WriteLine("1=Si, 2=No");

        var optionNewGroupSelected = int.Parse(Console.ReadLine());

        switch (optionNewGroupSelected)
        {
            case 1:
                {
                    Console.WriteLine($"Por favor ingrese el nombre para el nuevo grupo de {socialNetworkWithGroupsSelected.Name.ToLower()}");
                    string nameNewGroup = Console.ReadLine();

                    if(nameNewGroup != "")
                    {
                        int indexGroupElement = app.SocialNetworkWithGroups.IndexOf(socialNetworkWithGroupsSelected);
                        app.SocialNetworkWithGroups[indexGroupElement].Groups.Add(nameNewGroup);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un dato válido, no se ingresará ningún grupo");
                    }
                }
                break;
            case 2:
                break;
        }
    }

    Console.WriteLine("1=Agregar nuevo usuario, 2=Para ver las estadisticas, 3=Salir");

    var optionSelected = int.Parse(Console.ReadLine());

    switch (optionSelected)
    {
        case 1:
            {
                Console.WriteLine("Por favor ingrese su nombre");
                string name = Console.ReadLine();
                Console.WriteLine("Por favor ingrese su correo");
                string email = Console.ReadLine();
                Console.WriteLine("Por favor ingrese su edad");
                short age = short.Parse(Console.ReadLine());

                User user = new User();
                user.Name = name;
                user.Email = email;
                user.Age = age;

                if (user.isValid())
                {
                    Console.WriteLine("Los datos ingresados son:");
                    Console.WriteLine($"Su nombre es: {user.Name}");
                    Console.WriteLine($"Su correo es: {user.Email}");
                    Console.WriteLine($"Su edad es: {user.Age} años");
                    Console.WriteLine($"Su estado actual es: {user.IsActive}");
                    Console.WriteLine($"La fecha de creación es: {user.DateCreated.Day}/{user.DateCreated.Month}/{user.DateCreated.Year}");
                }
                else
                {
                    Console.WriteLine("Los datos ingresados no son válidos");
                }

                if (socialNetworkSelected != null)
                {
                    int indexElement = app.SocialNetworks.IndexOf(socialNetworkSelected);
                    app.SocialNetworks[indexElement].Users.Add(user);
                }

                if (socialNetworkWithGroupsSelected != null)
                {
                    int indexElement = app.SocialNetworkWithGroups.IndexOf(socialNetworkWithGroupsSelected);
                    app.SocialNetworkWithGroups[indexElement].Users.Add(user);
                }
            }
            break;
            case 2:
                if ( socialNetworkSelected != null )
                {
                    Console.WriteLine(app.GetSocialNetworkStats(socialNetworkSelected));
                }
                if (socialNetworkWithGroupsSelected != null)
                {
                    Console.WriteLine(app.GetSocialNetworkStats(socialNetworkWithGroupsSelected));
                }
            break;
            case 3:
                Console.WriteLine("Hasta luego !");
                keepGoingBucle = false;
            break;

    }

    

}



