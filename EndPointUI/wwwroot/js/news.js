
$(document).ready(function () {
    loadNews('0', 1);
});

function loadNews(type, part) {
    
    let body = {
        part: part,
        type: type
    };
    rest.postAsync("/GetNews", null, body, function (isSuccess, response) {
        debugger



        let currentType = parseInt(type);
        let activeTab = document.getElementById("list" + currentType );
        let btnMore = document.getElementById("more" + currentType );
        let culture = document.getElementById("culture").value;
        if (response.isSuccess) {
            activeTab.innerHTML = "";
            btnMore.removeAttribute("onclick");
            btnMore.style.display = "block";
            response.data.forEach((item, index) => {
                let image = '';
                let title = '';
                let topic = '';
                let dateTime = '';

                // Set image HTML with correct syntax
                if (item.imagePath === "default.jpg") {
                    image = '<img id="imagePath_1" src="/Gallery/default.jpg" class="img-last-news" />';
                } else {
                    image = '<img id="imagePath_1" src="/Gallery/News/' + item.imagePath + '" class="img-last-news" />';
                }

                // Set title and topic based on culture
                if (culture === "rtl") {
                    title = item.titleFa;
                    topic = item.topicTypeFa;
                    dateTime = item.createAtFa;
                } else {
                    title = item.titleEn;
                    topic = item.topicTypeEn;
                    dateTime = item.createAtEn;
                }

                // Determine text alignment based on culture
                let textAlign = (culture === "rtl") ? "right" : "left";

                // Generate the news HTML
                let news = `  <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12">
                <div class="card shadow" style="width: 100%">
                    ${image}
                    <div class="card-body body-last-news">
                        <p class="card-text" style="text-align:${textAlign}">${title}</p>
                    </div>
                    <p class="card-text p-3" style="text-align:${textAlign}"> <small class="text-info">${topic} - ${dateTime}</small></p>
                </div>  </div>
            `;
                activeTab.innerHTML += news; 
            });

            if (response.data.length >= response.count) {
                btnMore.style.display = "none";
            }else{
                btnMore.setAttribute("onclick", "loadNews('" + parseInt(type) + "','" + (response.current + 1) + "')");
            }
        }
    });
}