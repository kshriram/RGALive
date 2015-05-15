﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class UserMaster
    {
         public UserMaster() {

       }

     
       public Guid UserID { get; set; }
       public Guid RoleId { get; set; }
       public String UserFullName { get; set; }
       public String UserName { get; set; }
       public String UserAddress { get; set; }
       public DateTime UserJoiningDate { get; set; }
       public String UserPassword { get; set; }
       public DateTime CreatedDateTime { get; set; }
       public DateTime UpdatedDateTime { get; set; }
       public Guid CreatedBy { get; set; }
       public Guid Updatedby { get; set; }

       public UserMaster(GetRGAService.UserDTO _userDTO)
       {
           if (_userDTO.UserID != null) this.UserID = _userDTO.UserID;
           if (_userDTO.RoleID != null) this.RoleId = _userDTO.RoleID;
           if (_userDTO.UserFullName != null) this.UserFullName = _userDTO.UserFullName;
           if (_userDTO.UserName != null) this.UserName = _userDTO.UserName;
           if (_userDTO.UserAddress != null) this.UserAddress = _userDTO.UserAddress;
           if (_userDTO.UserJoiningDate != null) this.UserJoiningDate = (DateTime)_userDTO.UserJoiningDate;
           if (_userDTO.UserPassword != null) this.UserPassword = _userDTO.UserPassword;
           if (_userDTO.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_userDTO.CreatedDateTime;
           if (_userDTO.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_userDTO.UpdatedDateTime;
           if (_userDTO.CreatedBy != null) this.CreatedBy = (Guid)_userDTO.CreatedBy;
           if (_userDTO.Updatedby != null) this.Updatedby = (Guid)_userDTO.Updatedby;
       }

       public UserMaster(SetRGAService.UserDTO _userDTO)
       {
           if (_userDTO.UserID != null) this.UserID = _userDTO.UserID;
           if (_userDTO.RoleID != null) this.RoleId = _userDTO.RoleID;
           if (_userDTO.UserFullName != null) this.UserFullName = _userDTO.UserFullName;
           if (_userDTO.UserName != null) this.UserName = _userDTO.UserName;
           if (_userDTO.UserAddress != null) this.UserAddress = _userDTO.UserAddress;
           if (_userDTO.UserJoiningDate != null) this.UserJoiningDate = (DateTime)_userDTO.UserJoiningDate;
           if (_userDTO.UserPassword != null) this.UserPassword = _userDTO.UserPassword;
           if (_userDTO.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_userDTO.CreatedDateTime;
           if (_userDTO.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_userDTO.UpdatedDateTime;
           if (_userDTO.CreatedBy != null) this.CreatedBy = (Guid)_userDTO.CreatedBy;
           if (_userDTO.Updatedby != null) this.Updatedby = (Guid)_userDTO.Updatedby;
       }

       public SetRGAService.UserDTO ConvertTOSaveDTO(UserMaster _user)
       {
           SetRGAService.UserDTO _DTO = new SetRGAService.UserDTO();
           if (_user.UserID != null) this.UserID = _user.UserID;
           if (_user.RoleId != null) this.RoleId = _user.RoleId;
           if (_user.UserFullName != null) this.UserFullName = _user.UserFullName;
           if (_user.UserName != null) this.UserName = _user.UserName;
           if (_user.UserAddress != null) this.UserAddress = _user.UserAddress;
           if (_user.UserJoiningDate != null) this.UserJoiningDate = (DateTime)_user.UserJoiningDate;
           if (_user.UserPassword != null) this.UserPassword = _user.UserPassword;
           if (_user.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_user.CreatedDateTime;
           if (_user.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_user.UpdatedDateTime;
           if (_user.CreatedBy != null) this.CreatedBy = (Guid)_user.CreatedBy;
           if (_user.Updatedby != null) this.Updatedby = (Guid)_user.Updatedby;
           return _DTO;
       }

       public GetRGAService.UserDTO ConvertTOGetDTO(UserMaster _user)
       {
           GetRGAService.UserDTO _DTO = new GetRGAService.UserDTO();
           if (_user.UserID != null) this.UserID = _user.UserID;
           if (_user.RoleId != null) this.RoleId = _user.RoleId;
           if (_user.UserFullName != null) this.UserFullName = _user.UserFullName;
           if (_user.UserName != null) this.UserName = _user.UserName;
           if (_user.UserAddress != null) this.UserAddress = _user.UserAddress;
           if (_user.UserJoiningDate != null) this.UserJoiningDate = (DateTime)_user.UserJoiningDate;
           if (_user.UserPassword != null) this.UserPassword = _user.UserPassword;
           if (_user.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_user.CreatedDateTime;
           if (_user.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_user.UpdatedDateTime;
           if (_user.CreatedBy != null) this.CreatedBy = (Guid)_user.CreatedBy;
           if (_user.Updatedby != null) this.Updatedby = (Guid)_user.Updatedby;
           return _DTO;

       }
    }
}
