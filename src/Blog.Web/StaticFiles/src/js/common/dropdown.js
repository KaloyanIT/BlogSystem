import $ from 'jquery';

function onDropdownEvent() {
    if (!$(this).next().hasClass('show')) {
        $(this)
            .parents('.dropdown-menu')
            .first()
            .find('.show')
            .removeClass('show');
    }
    const $subMenu = $(this).next('.dropdown-menu');
    $subMenu.toggleClass('show');

    function hideDropdownEvent() {
        $('.dropdown-submenu .show').removeClass('show');
    }

    $(this)
        .parents('li.nav-item.dropdown.show')
        .on('hidden.bs.dropdown', hideDropdownEvent);

    return false;
}

$('.dropdown-menu a.dropdown-toggle').on('click', onDropdownEvent);
