var webClient = null;
var start_1c_edo_imp = function () {
    hide(document.getElementById('id1'));
    document.getElementById("webClientContainer").innerHTML = "";
    webClient = new WebClient1CE('webClientContainer',
        {
            /*webClientURL: 'http://1c.inlinegroup.ru/EDO_imp/ru_RU?N="Юрин Владимир Владимирович"', //&P=1*/
            /*webClientURL: 'http://10.7.64.243:82/local_edo_zup/ru_RU/',*/
            webClientURL: 'http://1c.inlinegroup.ru/EDO_imp/ru_RU',
            width: '100%',
            height: '100%'
        });
};
var start_ig_bd_test_web = function () {
    hide(document.getElementById('id1'));
    document.getElementById("webClientContainer").innerHTML = "";
    webClient = new WebClient1CE('webClientContainer',
        {
            webClientURL: 'http://1c-db-lists.inlinegroup.ru/DOC_osb/ru_RU/?N=Пользователь',
            /*webClientURL: 'http://10.7.64.243:82/ig_bd_test_web/ru_RU/',*/
            width: '100%',
            height: '100%'
        });
};
var start_1c_edo_imp_url_au = function () {
    hide(document.getElementById('id1'));
    document.getElementById("webClientContainer").innerHTML = "";
    param1 = document.getElementById("param1").innerHTML;
    param2 = document.getElementById('param2').innerHTML;
    webClient = new WebClient1CE('webClientContainer',
        {
            webClientURL: 'http://1c.inlinegroup.ru/EDO_imp/ru_RU?N="' + param1 + '"&P=' + param2 + '',
            width: '100%',
            height: '100%'
        });
};

window.onload = function () {
    var p_url = location.search.substring(1);
    var parametr = p_url.split("&");
    if (parametr.length > 1) {
        param1 = parametr[0].split("=")[1];
        param2 = parametr[1].split("=")[1];
        document.getElementById("param1").innerHTML = param1;
        document.getElementById('param2').innerHTML = param2;
        if ((param1 == "noUser") || (param2 == "noPass")) {
            start_1c_edo_imp();
        } else {
            start_1c_edo_imp_url_au();
        }
        //setLocation("http://my_loc_site.ru:82/");
        //setTimeout(setLocation_, 1000);
    };
    function setLocation(curLoc) {
        location.href = curLoc;
        location.hash = curLoc;
    }
};
function hide(element) {
    element.style.display = 'none';
}