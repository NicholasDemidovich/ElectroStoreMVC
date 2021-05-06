﻿$(document).ready(function () {

    
    $("a#pages").click(function () {
        if ($("a#pages").attr('class') == 'nav-link dropdown-toggle show') {
            $("ul#ulDropdownMenuIdPages").removeAttr('data-bs-popper');
            $("ul#ulDropdownMenuIdPages").attr('class', 'dropdown-menu');
            $("a#pages").attr('aria-expanded', 'false');
            $("a#pages").attr('class', 'nav-link dropdown-toggle');
        } else {
            $("a#pages").attr('class', 'nav-link dropdown-toggle show');
            $("a#pages").attr('aria-expanded', 'true');
            $("ul#ulDropdownMenuIdPages").attr('class', 'dropdown-menu show');
            $("ul#ulDropdownMenuIdPages").attr('data-bs-popper', 'none');
        }
    });

    $("a#pages").click(function () {
        if ($("div#mainDivPagesId").attr('class') == 'bottomPage') {
            $("div#mainDivPagesId").removeAttr('class');
        }
        else {
            $("div#mainDivPagesId").attr('class', 'bottomPage');
        }
    });


    const animItems = document.querySelectorAll('._anim-items');

    if (animItems.length > 0) {
        window.addEventListener('scroll', animOnScroll);
        function animOnScroll() {
            for (let index = 0; index < animItems.length; index++) {
                const animItem = animItems[index];
                const animItemHeight = animItem.offsetHeight;
                const animItemOffset = offset(animItem).top;
                const animStart = 4;

                let animItemPoint = window.innerHeight - animItemHeight / animStart;

                if (animItemHeight > window.innerHeight) {
                    animItemPoint = window.innerHeight - window.innerHeight / animStart;
                }

                if ((pageYOffset > animItemOffset - animItemPoint)
                    && pageYOffset < (animItemOffset + animItemHeight)) {
                    animItem.classList.add('_active');
                }
                else {
                    if (!animItem.classList.contains('_anim-no-hide')) {
                        animItem.classList.remove('_active');
                    }
                }
            }
        }

        function offset(el) {
            const rect = el.getBoundingClientRect(),
                scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
                scrollTop = window.pageYOffset || document.documentElement.scrollTop;
            return { top: rect.top + scrollTop, left: rect.left + scrollLeft }
        }

        setTimeout(() => {
            animOnScroll();
        }, 300);
    }

});