var TodaysDate;
var li=[];

function GetFormatedDate() {

    var fullDate = new Date();
    var twoDigitMonth = fullDate.getMonth()+1+ ""; if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;
    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
    TodaysDate= twoDigitMonth + "/" + twoDigitDate + "/" + fullDate.getFullYear()+"/";


}



function RenderSalesAmount(data) {
    $('#SellAmount').val(data);
}

function RenderPreCashAmount(data) {
    $('#PreCash').val(data);
}

function RenderTodaysExpense(data) {

    $('#Expenditure').val(data);
}

function RenderTodaysSales(data) {
    $('#RecentSales tbody tr ').remove();

    //var Total=0;
    var OrderCount=0;
    li = data;
    if (li.length <= 0) {
        $('#RecentSales tbody tr ').remove();
       

    }
    else {
        
        $.each(li, function (i, val) {
           

            
            var productItem = '<tr><td>' + val.RecieptId+'</td><td>' + val.NetAmount +  '</td></tr>';
           // Total = val.NetAmount + Total;
            OrderCount = i;

            $('#RecentSales tbody').append(productItem);


        });

    }
    $('#Salecount').html(OrderCount+1);
   // $('#Total').val(Total);


}
    




function LoadTodaysPreCashAmount(date) {

    $.ajax({
        type: 'GET',
        url: '/RecieptAccount/GetPreCashAmount',
        data: {
            'date': date
        },
        success: function (data) {

            RenderPreCashAmount(data);
        }
    });

}
function LoadTodaysSalesAmount(date) {

    $.ajax({
        type: 'GET',
        url: '/RecieptAccount/GetDailyExpenseSum',
        data: {
            'date': date
        },
        success: function(data) {

            RenderSalesAmount(data);
        }
    });

}


function LoadTodaysSales(date) {

    $.ajax({
        type: 'GET',
        url: '/RecieptAccount/TodaysSales',
        data: {
            'date': date
        },
        success: function (data) {

            RenderTodaysSales(data);
        }
    });

}

function LoadTodaysExpendetureAmount(date){


    $.ajax({
        type: 'GET',
        url: '/RecieptAccount/GetCurrentDateExpense',
        data: {
            'date': date
        },
        success: function (data) {

            RenderTodaysExpense(data);
        }
    });

}

function Refresh(parameters) {
   
}



function CheckBoxClick(NotificationId) {

   

    /*
    NotificationId = "#" + NotificationId;
    alert("'" + NotificationId + "'");
    $("'"+NotificationId+"'").remove();
    */
    alert("#" + NotificationId);
    $("#" + NotificationId).remove();
    
 $.ajax({
     type: 'Get',
     url: '/RecieptAccount/RemoveNotification',
     data:{'NotificationId': NotificationId },
    
     });
     



 
    /*
       alert(NotificationId);

    
    alert(NotificationId);


   $.ajax({
       type: "post",
       url: "",
       data:
       });
       */
    /*
    $(NotificationId).remove();
    */

}

function RenderNotification(data) {
    var li = data;

    if (li.length < 1) {

        $('NotificationError').css('visibility', 'visible');
    }

    else {

        $.each(li, function (i, val) {
            $('<div/>', {
                text: val.NotificationString,
                id: val.NotificationId.toString(),

                //id: 'notification' + (i + 1).toString(),
                class: 'form-group'
                

            }).appendTo('#NotificationPanel');



            $('<input/>', {
                type: "checkbox",
                id: 'notification' + (i + 1).toString() + 'CheckBox',
                class: 'form-group',
                onclick: 'CheckBoxClick("' + val.NotificationId+ '")'

        }).appendTo('#' + val.NotificationId.toString());


           


        });


            /*

             $('#Notification1 p').html("xyz");
            $('<div/>', {
                text: 'Div text',
                class: 'className'
            }).appendTo('#parentDiv');

            
           
            var x = $.create.element("checkbox");



            x.id = "notification" + "'" + (i + 1) + "'";
            $('#NotificationPanel').append(x);

            */
        
        
        // $('#Nf1Html').html()
    }

   

}

function LoadNotification(date) {
    $.ajax({
        type: 'GET',
        url: '/RecieptAccount/TodaysNotification',
        data: {
            'date': date
        },
        success: function (data) {

            RenderNotification(data);
        }
    });
    
}

function calculateTotal() {

    var sellamount = parseInt($('#SellAmount').val());
    var Expense = parseInt($('#Expenditure').val());
    var Amount = sellamount - Expense;
    $('#TotalValue').val(Amount);
}



$(document).ready(function () {
    GetFormatedDate();

    //$('#Expenditure').val(TodaysDate);
    LoadTodaysExpendetureAmount(TodaysDate);
    LoadTodaysSalesAmount(TodaysDate);
    LoadTodaysPreCashAmount(TodaysDate);
    LoadTodaysSales(TodaysDate);
    LoadNotification(TodaysDate);
    calculateTotal();

   // $('#Expenditure').val(TodaysDate);
    $('#Refresh').click(function () {
        LoadTodaysExpendetureAmount(TodaysDate);
        LoadTodaysSalesAmount(TodaysDate);
        LoadTodaysPreCashAmount(TodaysDate);
        LoadTodaysSales(TodaysDate);
        LoadNotification(TodaysDate);
        calculateTotal();
      
   });


});

