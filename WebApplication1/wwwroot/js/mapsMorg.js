ymaps.ready(init);

function init() {
    var myMap = new ymaps.Map('map', {
        center: [55.818128, 49.098001],
        zoom: 10
    });

    var markers = [];

    var addresses = [
        'Казань Республиканская клиническая больница №2, Муштари 13',
        'Казань Паталого-анатомическое отделение Республиканской психиатрической больницы на ул. Николая Ершова 49',
        'Казань Республиканское бюро судебно-медицинской экспертизы на Сибирский тракт 31а',
        'Казань Городская клиническая больница №7 на улице Маршала Чуйкова 54',
        'Казань Паталого-анатомическое отделение ДРКБ - Оренбургский тракт 140',
        'Казань Республиканская клиническая больница паталого-анатомическое отделение - Оренбургский тракт 138, корп.Л',
        'Казань ДРКБ №12 Паталого-анатомическое отделение - ул. Лечебная 7',
        'Казань Морг онкологического диспансера - Сибирский тракт 29',
        'Казань Межрегиональный клинико-диагностический центр (МКДЦ) - ул. Карбышева 12а',
        'Приемная: г. Казань, Пр. Победы, 69 Б',
    ];

    addresses.forEach(function (address) {
        addMarker(address);
    });

    function addMarker(address) {
        ymaps.geocode(address, {
            results: 1
        }).then(function (res) {
            var firstGeoObject = res.geoObjects.get(0);

            if (firstGeoObject) {
                var coords = firstGeoObject.geometry.getCoordinates();
                firstGeoObject.options.set('preset', 'islands#darkBlueDotIconWithCaption');
                firstGeoObject.properties.set('iconCaption', firstGeoObject.getAddressLine());

                myMap.geoObjects.add(firstGeoObject);

                // Сохранение координат метки
                markers.push({
                    address: address,
                    coords: coords
                });
            } else {
                console.log('Адрес не найден: ', address);
            }
        }).catch(function (err) {
            console.log('Ошибка геокодирования: ', err);
        });
    }

    document.querySelectorAll('.custom-button').forEach(function (button) {
        button.addEventListener('click', function () {
            var address = this.getAttribute('data-address');
            focusOnMarker(address);
        });
    });

    function focusOnMarker(address) {
        for (var i = 0; i < markers.length; i++) {
            if (markers[i].address === address) {
                myMap.setCenter(markers[i].coords, 16, {
                    checkZoomRange: true
                });
                break;
            }
        }
    }
}