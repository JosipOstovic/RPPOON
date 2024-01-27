using System;
using System.Collections.Generic;

    public interface IPermission
    {
        void Allow();
    }

    public class EditPermission : IPermission
    {
        public void Allow()
        {
            Console.WriteLine("User Has Edit Permission");
        }
    }

    public class DeletePermission : IPermission
    {
        public void Allow()
        {
            Console.WriteLine("User Has Delete Permission");
        }
    }

    public class CreatePermission : IPermission
    {
        public void Allow()
        {
            Console.WriteLine("User Has Create Permission");
        }
    }

    public class ViewPermission : IPermission
    {
        public void Allow()
        {
            Console.WriteLine("User Has View Permission");
        }
    }

    public interface IAccountConfigurator
    {
        void AddEditPermission(EditPermission permission);
        void AddDeletePermission(DeletePermission permission);
        void AddCreatePermission(CreatePermission permission);
        void AddViewPermission(ViewPermission permission);
        void ClearPermissions();
    }

    public class ConcreteAC : IAccountConfigurator
    {
        private Token token = new Token();

        public void AddEditPermission(EditPermission permission)
        {
            token.Add(permission);
            Console.WriteLine("User has Edit Permission");
        }

        public void AddDeletePermission(DeletePermission permission)
        {
            token.Add(permission);
            Console.WriteLine("User has Delete Permission");
        }

        public void AddCreatePermission(CreatePermission permission)
        {
            token.Add(permission);
            Console.WriteLine("User has Create Permission");
        }

        public void AddViewPermission(ViewPermission permission)
        {
            token.Add(permission);
            Console.WriteLine("User has View Permission");
        }

        public void ClearPermissions()
        {
            Console.WriteLine("Permissions cleared");
        }
    }

    public class Token
    {
        public List<IPermission> Permissions { get; } = new List<IPermission>();

        public void Add(IPermission permission)
        {
            Permissions.Add(permission);
        }

        public void Remove(IPermission permission)
        {
            Permissions.Remove(permission);
        }
    }

    public class PresetPermissions
    {
        public void Admin(IAccountConfigurator configurator)
        {
            configurator.AddEditPermission(new EditPermission());
            configurator.AddDeletePermission(new DeletePermission());
            configurator.AddCreatePermission(new CreatePermission());
            configurator.AddViewPermission(new ViewPermission());
        }

        public void User(IAccountConfigurator configurator)
        {
            configurator.AddViewPermission(new ViewPermission());
        }

        public void Manager(IAccountConfigurator configurator)
        {
            configurator.AddCreatePermission(new CreatePermission());
            configurator.AddEditPermission(new EditPermission());
            configurator.AddViewPermission(new ViewPermission());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccountConfigurator userAccountConfigurator = new ConcreteAC();
            PresetPermissions presetPermissions = new PresetPermissions();
            Console.WriteLine("Setting up Admin permissions:");
            presetPermissions.Admin(userAccountConfigurator);
            Console.WriteLine();
        }
    }

//Radi se o graditelju
