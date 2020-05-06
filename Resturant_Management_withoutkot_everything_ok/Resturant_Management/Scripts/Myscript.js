var products = [];
function LoadProducts(element1,element2) {

    if (products.length == 0) {
     
        $.ajax({

            type: "GET",
            url: '/Bills/GetProducts',
            success: function (data) {

                products = data;

                renderproducts(element1, element2);
            }

        }
            );
        
    }
    else {
        renderproducts(element1, element2);

    }
}



function renderproducts(element1)
{
    $ele1 = $(element1);
    $ele1.empty();

    $ele2 = $(element2);
    $ele2.empty();
    $ele1.append($('<option/>').val('0').text('Select Product'));
    
    $.each(products, function (i, val) {

        $ele1.append($('<option/>').val(val.ItemID).text(val.ItemName));
        $ele2.append($('value').val(val.ItemID).text(val.ItemUnitPrice));

    });



}

function LoadUnitPrice(categoryDD) {
    $.ajax({
        type: "GET",
        url: "/Bills/GetProductUnitPrice",
        data: { 'ItemID': $(categoryDD).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderProduct($(categoryDD).parents('.mycontainer').find('UnitPrice'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}


function renderProduct(element, data) {
    //render product
    var $ele = $(element);
    $ele.empty();
    $ele.append($('UnitPrice').val(data.ItemID).text('ItemUnitPrice'));
   
}
$(document).ready(function(){
    
    });

LoadProducts('#product ','#UnitPrice')
