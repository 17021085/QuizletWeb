$(document).ready(function () {
    home = new homeJS();
    
})
class homeJS{
    constructor(){
    var me = this;
        me.loadData()
    //   me.initEvent();
    }
   loadData(){
    $.ajax({
        url: "/api/FlashCards",
        method: "GET",
        data: {},
        dataType: "json",
        contentType: "application/json",
    }).done(function (response) {
        if (response) {
            $.each(response, function (index, item) {

                var EmployeeIndex = $(`<a href="">
                <div class="list-set">
                    <div class="doc-icon">
                        <img src="/content/images/doc.png" alt="">
                    </div>
                    <div class="doc-set">
                        <div class="name-class">
                            <h3>`+item['flashcardtitle']+`</h3>
                        </div>
                        <div class="des-class">
                           <p>`+item['descriptioncard']+`</p>
                        </div>
                    </div>
                </div>
            </a>`);
                         $('.main').append(EmployeeIndex);
              
            });
            
        }
    }).fail(function (response) {
        alert("fail");
    });   }
    
}