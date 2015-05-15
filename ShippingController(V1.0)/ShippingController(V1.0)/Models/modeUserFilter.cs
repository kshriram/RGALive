using PackingClassLibrary.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Models
{
    public class modelUserFilter
    {
        public static Boolean IsNameFilterOn = false;
        public static Boolean IsDateFilterOn = false;
        public static Boolean IsAddressFilterOn = false;
        public static Boolean IsRoleFilterOn = false;
        public static Boolean IsFullNameFilterOn = false;

        protected static String _userName;
        protected static String _userFullName;
        protected static String _address;
        protected static String _role;
        protected static DateTime _jFromDate;
        protected static DateTime _jToDate;

        #region Property Declarations
        public static String UserName
        {
            get { return _userName; }
            set {
                IsNameFilterOn = true;
                _userName = value;
            }
        }

        public static String UserFullName
        {
            get { return _userFullName; }
            set
            {
                IsFullNameFilterOn = true;
                _userFullName = value;
            }
        }

        public static String Address
        {
            get { return _address; }
            set
            {
                IsAddressFilterOn = true;
                _address = value;
            }
        }

        public static String Role
        {
            get { return _role; }
            set
            {
                IsRoleFilterOn = true;
                _role = value;
            }
        }

        public static DateTime JoiningFromDate
        {
            get { return _jFromDate; }
            set
            {
                IsDateFilterOn = true;
                _jFromDate = value;
            }
        }
        public static DateTime JoiningToDate
        {
            get { return _jToDate; }
            set
            {
                IsDateFilterOn = true;
                _jToDate = value;
            }
        }
        #endregion

        /// <summary>
        /// Filtering Logic
        /// </summary>
        /// <returns>Filtered List of Users</returns>
        public static List<cstUserMasterTbl> GetUserInfo()
        {
            List<cstUserMasterTbl> _lsReturn = Obj.call.GetUserInfoList();
            try
            {
                if (IsNameFilterOn)
                {
                    List<cstUserMasterTbl> _lsTemp = new List<cstUserMasterTbl>();
                    foreach (cstUserMasterTbl _userItem in _lsReturn)
                    {
                        if (_userItem.UserName.ToUpper().Contains(_userName.ToUpper()))
                        {
                            _lsTemp.Add(_userItem);
                        }
                    }
                    _lsReturn = _lsTemp;
                }

                if (IsDateFilterOn)
                {
                    List<cstUserMasterTbl> _lsTemp = new List<cstUserMasterTbl>();
                    if (_jFromDate != null && _jToDate != null)
                    {
                        foreach (cstUserMasterTbl _userItem in _lsReturn)
                        {
                            if (_userItem.JoiningDate>= _jFromDate && _userItem.JoiningDate <= _jToDate  )
                            {
                                _lsTemp.Add(_userItem);
                            }
                        }
                    }
                    _lsReturn = _lsTemp;
                }

                if (IsAddressFilterOn)
                {
                    List<cstUserMasterTbl> _lsTemp = new List<cstUserMasterTbl>();
                    foreach (cstUserMasterTbl _userItem in _lsReturn)
                    {
                        if (_userItem.UserAddress.ToUpper().Contains(_address.ToUpper()))
                        {
                            _lsTemp.Add(_userItem);
                        }
                    }
                    _lsReturn = _lsTemp;
                }

                if (IsRoleFilterOn)
                {
                    List<cstUserMasterTbl> _lsTemp = new List<cstUserMasterTbl>();
                    foreach (cstUserMasterTbl _userItem in _lsReturn)
                    {
                        if (_userItem.RoleName.ToUpper().Contains(_role.ToUpper()))
                        {
                            _lsTemp.Add(_userItem);
                        }
                    }
                    _lsReturn = _lsTemp;
                }

                if (IsFullNameFilterOn)
                {
                    List<cstUserMasterTbl> _lsTemp = new List<cstUserMasterTbl>();
                    foreach (cstUserMasterTbl _userItem in _lsReturn)
                    {
                        if (_userItem.UserFullName.ToUpper().Contains(_userFullName.ToUpper()))
                        {
                            _lsTemp.Add(_userItem);
                        }
                    }
                    _lsReturn = _lsTemp;
                }
            }
            catch (Exception)
            {
            }
            return _lsReturn;
        }

    }
}