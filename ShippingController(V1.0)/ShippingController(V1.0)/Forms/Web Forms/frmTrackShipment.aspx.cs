using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using ShippingController_V1._0_.Models;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts;
using PackingClassLibrary.Commands;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class frmTrackShipment : System.Web.UI.Page
    {

        private void Page_PreInit(object sender, EventArgs e)
        {
            //string user = Session["UserID"].ToString().ToUpper();
            //if (Session["UserID"].ToString().ToUpper() == "0DD3CB2D-33B6-431F-9DA0-042F9FF3963B")
            string role = Session["RoleID"].ToString().ToUpper();
            if (Session["RoleID"].ToString().ToUpper() == "077A2FA0-88D3-4732-9D7B-203D6DE2D875")
            {
                this.MasterPageFile = "~/Forms/Master Forms/Admin.Master";
            }
            else
            {
                this.MasterPageFile = "~/Forms/Master Forms/TestUser.Master";
            }

        }


      protected void Page_Load(object sender, EventArgs e)
        {
           
          
        }

      #region Tracking Graph
      public void SetGraph(List<cstShipmentNumStatus> _lsGrapgPar)
      {
          Series[] sr = null;
          String[] Locations = new String[_lsGrapgPar.Count];
          List<object[]> lsObj = new List<object[]>();
       
          
          #region multilocation shipment data 
        if (_lsGrapgPar.Count > 1 && _lsGrapgPar[0].ShippingCompletedInt != _lsGrapgPar[1].ShippingCompletedInt)
        {
            if (_lsGrapgPar[1].ShippingCompletedInt > _lsGrapgPar[0].ShippingCompletedInt)
            {

                int lsdiff = _lsGrapgPar[1].ShippingCompletedInt - _lsGrapgPar[0].ShippingCompletedInt;
                for (int i = 0; i < _lsGrapgPar[0].ShippingCompletedInt; i++)
                    {
                        object[] a = new object[] { 1, 1 };
                        lsObj.Add(a);
                    }

                for (int i = 0; i < lsdiff; i++)
                {
                    object[] a = new object[] { 1 };
                    lsObj.Add(a);
                }
            }
            else if (_lsGrapgPar[0].ShippingCompletedInt > _lsGrapgPar[1].ShippingCompletedInt)
            {
                int lsdiff = _lsGrapgPar[0].ShippingCompletedInt - _lsGrapgPar[1].ShippingCompletedInt;
                for (int i = 0; i < _lsGrapgPar[1].ShippingCompletedInt; i++)
                    {
                        object[] a = new object[] { 1, 1 };
                        lsObj.Add(a);
                    }

                for (int i = 0; i < lsdiff; i++)
                {
                    object[] a = new object[] { 1 };
                    lsObj.Add(a);
                }
            }
        }
        else if (_lsGrapgPar.Count > 1 && _lsGrapgPar[0].ShippingCompletedInt == _lsGrapgPar[1].ShippingCompletedInt)
        {
            for (int i = 0; i < _lsGrapgPar.Max(j => j.ShippingCompletedInt); i++)
            {
                object[] a = new object[] { 1,1 };
                lsObj.Add(a);
            }
        }
        #endregion

          //Add locations to graph
        for (int i = 0; i < _lsGrapgPar.Count; i++)
        {
            Locations[i] = _lsGrapgPar[i].Location.ToString();
        }

          foreach (cstShipmentNumStatus item in _lsGrapgPar)
          {
              if (_lsGrapgPar.Count > 1) //Multilocation Shipment
              {
                  #region multilocation Shipment
                  if (_lsGrapgPar.Max(i => i.ShippingCompletedInt) == 4)
                  {
                      sr = new Series[4];
                      sr[0] = new Series { Name = "Packing", Data = new Data(lsObj[3].ToArray()), Color = System.Drawing.Color.FromArgb(222, 230, 26) };
                      sr[1] = new Series { Name = "Picking ", Data = new Data(lsObj[2].ToArray()), Color = System.Drawing.Color.FromArgb(233, 190, 35) };
                      sr[2] = new Series { Name = "Allocated", Data = new Data(lsObj[1].ToArray()), Color = System.Drawing.Color.FromArgb(233, 128, 35) };
                      sr[3] = new Series { Name = "New", Data = new Data(lsObj[0].ToArray()), Color = System.Drawing.Color.FromArgb(233, 81, 35) };
                  }
                  else if (_lsGrapgPar.Max(i => i.ShippingCompletedInt) == 5)
                  {
                      sr = new Series[5];
                      sr[0] = new Series { Name = "Shipping", Data = new Data(lsObj[4].ToArray()), Color = System.Drawing.Color.FromArgb(193, 230, 26) };
                      sr[1] = new Series { Name = "Packing", Data = new Data(lsObj[3].ToArray()), Color = System.Drawing.Color.FromArgb(222, 230, 26) };
                      sr[2] = new Series { Name = "Picking ", Data = new Data(lsObj[2].ToArray()), Color = System.Drawing.Color.FromArgb(233, 190, 35) };
                      sr[3] = new Series { Name = "Allocated", Data = new Data(lsObj[1].ToArray()), Color = System.Drawing.Color.FromArgb(233, 128, 35) };
                      sr[4] = new Series { Name = "New", Data = new Data(lsObj[0].ToArray()), Color = System.Drawing.Color.FromArgb(233, 81, 35) };
                  }
                  else if (_lsGrapgPar.Max(i => i.ShippingCompletedInt) == 6)
                  {
                      sr = new Series[6];
                      sr[0] = new Series { Name = "Shipped", Data = new Data(lsObj[5].ToArray()), Color = System.Drawing.Color.FromArgb(170, 230, 26) };
                      sr[1] = new Series { Name = "Shipping", Data = new Data(lsObj[4].ToArray()), Color = System.Drawing.Color.FromArgb(193, 230, 26) };
                      sr[2] = new Series { Name = "Packing", Data = new Data(lsObj[3].ToArray()), Color = System.Drawing.Color.FromArgb(222, 230, 26) };
                      sr[3] = new Series { Name = "Picking ", Data = new Data(lsObj[2].ToArray()), Color = System.Drawing.Color.FromArgb(233, 190, 35) };
                      sr[4] = new Series { Name = "Allocated", Data = new Data(lsObj[1].ToArray()), Color = System.Drawing.Color.FromArgb(233, 128, 35) };
                      sr[5] = new Series { Name = "New", Data = new Data(lsObj[0].ToArray()), Color = System.Drawing.Color.FromArgb(233, 81, 35) };
                  }
                  #endregion
              }
              else //Single location Shipment
              {
                  #region Single location 
                  if (item.ShippingCompletedInt == 4)
                  {
                      sr = new Series[4];
                      sr[0] = new Series { Name = "Packing", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(222, 230, 26) };
                      sr[1] = new Series { Name = "Picking ", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 190, 35) };
                      sr[2] = new Series { Name = "Allocated", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 128, 35) };
                      sr[3] = new Series { Name = "New", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 81, 35) };
                  }
                  else if (item.ShippingCompletedInt == 5)
                  {
                      sr = new Series[5];
                      sr[0] = new Series { Name = "Shipping", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(193, 230, 26) };
                      sr[1] = new Series { Name = "Packing", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(222, 230, 26) };
                      sr[2] = new Series { Name = "Picking ", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 190, 35) };
                      sr[3] = new Series { Name = "Allocated", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 128, 35) };
                      sr[4] = new Series { Name = "New", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 81, 35) };
                  }
                  else if (item.ShippingCompletedInt == 6)
                  {
                      sr = new Series[6];
                      sr[0] = new Series { Name = "Shipped", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(170, 230, 26) };
                      sr[1] = new Series { Name = "Shipping", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(193, 230, 26) };
                      sr[2] = new Series { Name = "Packing", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(222, 230, 26) };
                      sr[3] = new Series { Name = "Picking ", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 190, 35) };
                      sr[4] = new Series { Name = "Allocated", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 128, 35) };
                      sr[5] = new Series { Name = "New", Data = new Data(new object[] { 1 }), Color = System.Drawing.Color.FromArgb(233, 81, 35) };
                  }
                  #endregion
              }

              #region Chart code
              Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart
                {
                    Type = ChartTypes.Bar,
                    BackgroundColor = new BackColorOrGradient(System.Drawing.Color.Transparent)
                })
                .SetTitle(new Title
                {
                    Text = "Shipment Tracking :- " + item.ShippingNum,
                    Style = "fontSize: '30px',fontFamily: 'Verdana', fontBold: 'true', color: 'White' "
                })
                .SetXAxis(new XAxis
                {
                    Categories = (Locations),
                    Labels = new XAxisLabels { Style = "fontSize: '25px', fontFamily: 'Verdana', fontBold: 'true', color: 'White'" }
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle { Text = "", Style = "fontSize: '15px', fontFamily: 'Verdana', color: 'White'" },
                    Labels = new YAxisLabels { Enabled = false },
                    GridLineWidth = 0
                })
                .SetTooltip(new Tooltip { Formatter = "function() { return this.series.name +'<br/>'+ this.x}" })
                .SetPlotOptions(new PlotOptions
                {
                    Bar = new PlotOptionsBar
                    {
                        Stacking = Stackings.Normal,
                        Shadow = true,

                        DataLabels = new PlotOptionsBarDataLabels
                        {
                            Enabled = true,
                            Formatter = "function() { return this.series.name; }",
                            Color = System.Drawing.Color.Black,
                            Style = "fontSize: '25px', fontFamily: 'Verdana', fontBold: 'true', color: 'Black'"
                        },
                      //   Events = new PlotOptionsBarEvents { Click = "function() {''}" },
                        PointWidth = 70,
                        Point = new PlotOptionsBarPoint
                        {
                            Events = new PlotOptionsBarPointEvents { Click = " function() { location.href ='/Forms/Web Forms/frmShipmentInfoALl.aspx?location='+ this.category; }" }
                        }//'+ this.series.name +'
                    }
                })
                .SetSeries(sr)
                .SetLegend(new Legend
                {
                    BackgroundColor = new BackColorOrGradient(System.Drawing.Color.WhiteSmoke),
                    Align = HorizontalAligns.Center
                });

              #endregion


              Session["PackingID"] = item.ShippingNum.ToString();
              

              //Chart js display on litral
              ltrChart.Text = chart.ToHtmlString();
          }
      }
      #endregion

      protected void txtShippingNumber_TextChanged(object sender, EventArgs e)
      {
          List<cstShipmentNumStatus> _lsGrapgPar = Obj.Rcall.GetShippingStatus(txtShippingNumber.Text);
          SetGraph(_lsGrapgPar);
      }
    }
}