using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.CustomEntity;

namespace PackingClassLibrary.Commands
{
    class cmdUpdateRole : cmdAbstractEntity<cstRoleTbl>
    {
        csteActionenum _action;
        cstRoleTbl _role;
        Guid _id;

        public cmdUpdateRole() { }

        public cmdUpdateRole(cstRoleTbl role, csteActionenum action)
        {
            _role = role;
            _action = action;
        }
        public cmdUpdateRole(Guid Id, csteActionenum action)
        {
            _id = Id;
            _action = action;
        }
        public override List<cstRoleTbl> Execute()
        {
            List<cstRoleTbl> roleList = new List<cstRoleTbl>();

          //  local_x3v6Entities context = new local_x3v6Entities();
            switch (_action)
            {
                case csteActionenum.New:
                    SetService.RoleDTO role = new SetService.RoleDTO();
                    role.RoleID = Guid.NewGuid();
                    role.Name = _role.Name;
                    role.Action = _role.Action;
                    role.CreatedBy = GlobalClasses.ClGlobal.UserID;
                    role.CreatedDateTime = DateTime.UtcNow;

                    List<SetService.RoleDTO> _lsrole = new List<SetService.RoleDTO>();
                    _lsrole.Add(role);
                    var r = _lsrole.ToArray();
                    bool v = Service.Set.Role(r);
                    //context.AddToRoles(r);
                    //context.SaveChanges();
                    break;

                case csteActionenum.Update:
                    var roleTypeUpdate =Service.Get.RoleByRoleID(_role.RoleId);  //context.Roles.First(i => i.RoleId == _role.RoleId);

                    foreach (var item in roleTypeUpdate)
                    {
                        item.Name = _role.Name;
                        item.Action = _role.Action;
                        item.Updatedby = GlobalClasses.ClGlobal.UserID;
                        item.UpdatedDateTime = DateTime.UtcNow;
                    }

                    //context.SaveChanges();
                    break;                       

                case csteActionenum.Delete:
                    break;
                
                case csteActionenum.Get:
                    var result = from r1 in Service.Get.RoleAllRoles() //context.Roles
                                  where r1.RoleID == _id
                                  select r1;
                    foreach (var varRole in result)
                    {
                        cstRoleTbl objRole = new cstRoleTbl();
                        objRole.RoleId = varRole.RoleID;
                        objRole.Name = varRole.Name;
                        objRole.Action = varRole.Action;
                        roleList.Add(objRole);
                    }
                    break;               
            }

            return roleList;
        }


    }
}
