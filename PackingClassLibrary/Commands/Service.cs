using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.Commands
{
    public static class Service
    {

        /// <summary>
        /// Get Service Call
        /// </summary>
        public static GetService.GetClient Get = new GetService.GetClient();

        /// <summary>
        /// Set service call;
        /// </summary>
        public static SetService.SaveClient Set = new SetService.SaveClient();


        /// <summary>
        /// Delete service call;
        /// </summary>
        public static DeleteService.DeleteClient delete = new DeleteService.DeleteClient();

        /// <summary>
        /// RGA Service 
        /// </summary>
        public static GetRGAService.GetClient GetRMA = new GetRGAService.GetClient();


        /// <summary>
        /// RGA service.
        /// </summary>
        public static SetRGAService.SaveClient SetRMA = new SetRGAService.SaveClient();

        /// <summary>
        /// Delete RMA service
        /// </summary>
        public static DeleteRMAService.DeleteClient DeleteRMA = new DeleteRMAService.DeleteClient();

    }
}
