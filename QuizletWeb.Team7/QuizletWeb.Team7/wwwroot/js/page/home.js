

$(document).ready(function () {
    home = new homeJS();
    
})
class homeJS{
    constructor(){
    var me = this;
        me.loadData()
        me.initEvent();
       
    }

    initEvent() {
        $('#create-item').click(this.createfc);
        $('#home-create').click(this.add);
       
    }

    add() {
       
        var me = this;
        var fc = {}
        fc.classid = "animal";
        fc.flashcardid = $('#flashcardid').val();
        fc.flashcardtitle = $('#flashcardtitle').val();
        fc.descriptioncard = $('#descriptioncard').val();
        fc.image = null;
        fc.class = null;
            $.ajax({
                url: "/api/Flashcards",
                method: "POST",
                data: JSON.stringify(fc),
                dataType: "text",
                contentType: "application/json",
            }).done(function (response) {
                //me.loadData();
                debugger
                console.log(fc);
                
            }).fail(function (response) {
                console.log("Them that bai");
                console.log(fc);
                debugger
            })
        $("#dialog").dialog("close");
         
          
        
    }

    createfc() {    
       
        $("#dialog").dialog({
            autoOpen: false,
            show: {
                effect: "blind",
                duration: 1000
            },
            hide: {
                effect: "explode",
                duration: 1000
            }
        });
        $("#create-item").on("click", function () {
            $("#dialog").dialog("open");
        });
    }


    loadData() {
        $.ajax({
            url: "/api/FlashCards",
            method: "GET",
            data: {},
            dataType: "json",
            contentType: "application/json",
        }).done(function (response) {
            if (response) {
                $.each(response, function (index, item) {

                    var EmployeeIndex = $(`<div id="` + item['flashcardid'] +`" class="carousel slide container-cr " data-ride="carousel" ">
                    <div class="carousel-inner inner-cr ">
                        <div class="carousel-item active ">
                            <h3 >`+ item['flashcardtitle']+`</h3>
                        </div>
                        <div class="carousel-item ">
                          <h3 style="top:50%;left:50%">  `+ item['descriptioncard'] + `</h3>
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="`+item['image']+`" alt="Third slide">
                        </div>
                    </div>
                    <a class="carousel-control-prev" href="#` + item['flashcardid'] +`" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#` + item['flashcardid'] +`" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                     
                    </a>
                </div>`);
                    $('.main').append(EmployeeIndex);

                });

            }
        }).fail(function (response) {
            alert("fail");
        });
    }
   
}