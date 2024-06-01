/**
 * AdminLTE Demo Menu
 * ------------------
 * You should not use this file in production.
 * This file is for demo purposes only.
 */

/* eslint-disable camelcase */

(function ($) {
  'use strict'

  setTimeout(function () {
    if (window.___browserSync___ === undefined && Number(localStorage.getItem('AdminLTE:Demo:MessageShowed')) < Date.now()) {
      localStorage.setItem('AdminLTE:Demo:MessageShowed', (Date.now()) + (15 * 60 * 1000))
      // eslint-disable-next-line no-alert
      alert('You load AdminLTE\'s "demo.js", \nthis file is only created for testing purposes!')
    }
  }, 1000)

  function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1)
  }

  function createSkinBlock(colors, callback, noneSelected) {
    var $block = $('<select />', {
      class: noneSelected ? 'custom-select mb-3 border-0' : 'custom-select mb-3 text-light border-0 ' + colors[0].replace(/accent-|navbar-/, 'bg-')
    })

    if (noneSelected) {
      var $default = $('<option />', {
        text: 'None Selected'
      })

      $block.append($default)
    }

    colors.forEach(function (color) {
      var $color = $('<option />', {
        class: (typeof color === 'object' ? color.join(' ') : color).replace('navbar-', 'bg-').replace('accent-', 'bg-'),
        text: capitalizeFirstLetter((typeof color === 'object' ? color.join(' ') : color).replace(/navbar-|accent-|bg-/, '').replace('-', ' '))
      })

      $block.append($color)
    })
    if (callback) {
      $block.on('change', callback)
    }

    return $block
  }

  var $sIdebar = $('.control-sIdebar')
  var $container = $('<div />', {
    class: 'p-3 control-sIdebar-content'
  })

  $sIdebar.append($container)

  // Checkboxes

  $container.append(
    '<h5>Customize AdminLTE</h5><hr class="mb-2"/>'
  )

  var $dark_mode_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('dark-mode'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('dark-mode')
    } else {
      $('body').removeClass('dark-mode')
    }
  })
  var $dark_mode_container = $('<div />', { class: 'mb-4' }).append($dark_mode_checkbox).append('<span>Dark Mode</span>')
  $container.append($dark_mode_container)

  $container.append('<h6>Header Options</h6>')
  var $header_fixed_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('layout-navbar-fixed'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('layout-navbar-fixed')
    } else {
      $('body').removeClass('layout-navbar-fixed')
    }
  })
  var $header_fixed_container = $('<div />', { class: 'mb-1' }).append($header_fixed_checkbox).append('<span>Fixed</span>')
  $container.append($header_fixed_container)

  var $dropdown_legacy_offset_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.main-header').hasClass('dropdown-legacy'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.main-header').addClass('dropdown-legacy')
    } else {
      $('.main-header').removeClass('dropdown-legacy')
    }
  })
  var $dropdown_legacy_offset_container = $('<div />', { class: 'mb-1' }).append($dropdown_legacy_offset_checkbox).append('<span>Dropdown Legacy Offset</span>')
  $container.append($dropdown_legacy_offset_container)

  var $no_border_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.main-header').hasClass('border-bottom-0'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.main-header').addClass('border-bottom-0')
    } else {
      $('.main-header').removeClass('border-bottom-0')
    }
  })
  var $no_border_container = $('<div />', { class: 'mb-4' }).append($no_border_checkbox).append('<span>No border</span>')
  $container.append($no_border_container)

  $container.append('<h6>SIdebar Options</h6>')

  var $sIdebar_collapsed_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('sIdebar-collapse'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('sIdebar-collapse')
      $(window).trigger('resize')
    } else {
      $('body').removeClass('sIdebar-collapse')
      $(window).trigger('resize')
    }
  })
  var $sIdebar_collapsed_container = $('<div />', { class: 'mb-1' }).append($sIdebar_collapsed_checkbox).append('<span>Collapsed</span>')
  $container.append($sIdebar_collapsed_container)

  $(document).on('collapsed.lte.pushmenu', '[data-wIdget="pushmenu"]', function () {
    $sIdebar_collapsed_checkbox.prop('checked', true)
  })
  $(document).on('shown.lte.pushmenu', '[data-wIdget="pushmenu"]', function () {
    $sIdebar_collapsed_checkbox.prop('checked', false)
  })

  var $sIdebar_fixed_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('layout-fixed'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('layout-fixed')
      $(window).trigger('resize')
    } else {
      $('body').removeClass('layout-fixed')
      $(window).trigger('resize')
    }
  })
  var $sIdebar_fixed_container = $('<div />', { class: 'mb-1' }).append($sIdebar_fixed_checkbox).append('<span>Fixed</span>')
  $container.append($sIdebar_fixed_container)

  var $sIdebar_mini_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('sIdebar-mini'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('sIdebar-mini')
    } else {
      $('body').removeClass('sIdebar-mini')
    }
  })
  var $sIdebar_mini_container = $('<div />', { class: 'mb-1' }).append($sIdebar_mini_checkbox).append('<span>SIdebar Mini</span>')
  $container.append($sIdebar_mini_container)

  var $sIdebar_mini_md_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('sIdebar-mini-md'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('sIdebar-mini-md')
    } else {
      $('body').removeClass('sIdebar-mini-md')
    }
  })
  var $sIdebar_mini_md_container = $('<div />', { class: 'mb-1' }).append($sIdebar_mini_md_checkbox).append('<span>SIdebar Mini MD</span>')
  $container.append($sIdebar_mini_md_container)

  var $sIdebar_mini_xs_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('sIdebar-mini-xs'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('sIdebar-mini-xs')
    } else {
      $('body').removeClass('sIdebar-mini-xs')
    }
  })
  var $sIdebar_mini_xs_container = $('<div />', { class: 'mb-1' }).append($sIdebar_mini_xs_checkbox).append('<span>SIdebar Mini XS</span>')
  $container.append($sIdebar_mini_xs_container)

  var $flat_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.nav-sIdebar').hasClass('nav-flat'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.nav-sIdebar').addClass('nav-flat')
    } else {
      $('.nav-sIdebar').removeClass('nav-flat')
    }
  })
  var $flat_sIdebar_container = $('<div />', { class: 'mb-1' }).append($flat_sIdebar_checkbox).append('<span>Nav Flat Style</span>')
  $container.append($flat_sIdebar_container)

  var $legacy_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.nav-sIdebar').hasClass('nav-legacy'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.nav-sIdebar').addClass('nav-legacy')
    } else {
      $('.nav-sIdebar').removeClass('nav-legacy')
    }
  })
  var $legacy_sIdebar_container = $('<div />', { class: 'mb-1' }).append($legacy_sIdebar_checkbox).append('<span>Nav Legacy Style</span>')
  $container.append($legacy_sIdebar_container)

  var $compact_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.nav-sIdebar').hasClass('nav-compact'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.nav-sIdebar').addClass('nav-compact')
    } else {
      $('.nav-sIdebar').removeClass('nav-compact')
    }
  })
  var $compact_sIdebar_container = $('<div />', { class: 'mb-1' }).append($compact_sIdebar_checkbox).append('<span>Nav Compact</span>')
  $container.append($compact_sIdebar_container)

  var $child_indent_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.nav-sIdebar').hasClass('nav-child-indent'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.nav-sIdebar').addClass('nav-child-indent')
    } else {
      $('.nav-sIdebar').removeClass('nav-child-indent')
    }
  })
  var $child_indent_sIdebar_container = $('<div />', { class: 'mb-1' }).append($child_indent_sIdebar_checkbox).append('<span>Nav Child Indent</span>')
  $container.append($child_indent_sIdebar_container)

  var $child_hIde_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.nav-sIdebar').hasClass('nav-collapse-hIde-child'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.nav-sIdebar').addClass('nav-collapse-hIde-child')
    } else {
      $('.nav-sIdebar').removeClass('nav-collapse-hIde-child')
    }
  })
  var $child_hIde_sIdebar_container = $('<div />', { class: 'mb-1' }).append($child_hIde_sIdebar_checkbox).append('<span>Nav Child HIde on Collapse</span>')
  $container.append($child_hIde_sIdebar_container)

  var $no_expand_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.main-sIdebar').hasClass('sIdebar-no-expand'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.main-sIdebar').addClass('sIdebar-no-expand')
    } else {
      $('.main-sIdebar').removeClass('sIdebar-no-expand')
    }
  })
  var $no_expand_sIdebar_container = $('<div />', { class: 'mb-4' }).append($no_expand_sIdebar_checkbox).append('<span>Disable Hover/Focus Auto-Expand</span>')
  $container.append($no_expand_sIdebar_container)

  $container.append('<h6>Footer Options</h6>')
  var $footer_fixed_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('layout-footer-fixed'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('layout-footer-fixed')
    } else {
      $('body').removeClass('layout-footer-fixed')
    }
  })
  var $footer_fixed_container = $('<div />', { class: 'mb-4' }).append($footer_fixed_checkbox).append('<span>Fixed</span>')
  $container.append($footer_fixed_container)

  $container.append('<h6>Small Text Options</h6>')

  var $text_sm_body_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('body').hasClass('text-sm'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('body').addClass('text-sm')
    } else {
      $('body').removeClass('text-sm')
    }
  })
  var $text_sm_body_container = $('<div />', { class: 'mb-1' }).append($text_sm_body_checkbox).append('<span>Body</span>')
  $container.append($text_sm_body_container)

  var $text_sm_header_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.main-header').hasClass('text-sm'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.main-header').addClass('text-sm')
    } else {
      $('.main-header').removeClass('text-sm')
    }
  })
  var $text_sm_header_container = $('<div />', { class: 'mb-1' }).append($text_sm_header_checkbox).append('<span>Navbar</span>')
  $container.append($text_sm_header_container)

  var $text_sm_brand_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.brand-link').hasClass('text-sm'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.brand-link').addClass('text-sm')
    } else {
      $('.brand-link').removeClass('text-sm')
    }
  })
  var $text_sm_brand_container = $('<div />', { class: 'mb-1' }).append($text_sm_brand_checkbox).append('<span>Brand</span>')
  $container.append($text_sm_brand_container)

  var $text_sm_sIdebar_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.nav-sIdebar').hasClass('text-sm'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.nav-sIdebar').addClass('text-sm')
    } else {
      $('.nav-sIdebar').removeClass('text-sm')
    }
  })
  var $text_sm_sIdebar_container = $('<div />', { class: 'mb-1' }).append($text_sm_sIdebar_checkbox).append('<span>SIdebar Nav</span>')
  $container.append($text_sm_sIdebar_container)

  var $text_sm_footer_checkbox = $('<input />', {
    type: 'checkbox',
    value: 1,
    checked: $('.main-footer').hasClass('text-sm'),
    class: 'mr-1'
  }).on('click', function () {
    if ($(this).is(':checked')) {
      $('.main-footer').addClass('text-sm')
    } else {
      $('.main-footer').removeClass('text-sm')
    }
  })
  var $text_sm_footer_container = $('<div />', { class: 'mb-4' }).append($text_sm_footer_checkbox).append('<span>Footer</span>')
  $container.append($text_sm_footer_container)

  // Color Arrays

  var navbar_dark_skins = [
    'navbar-primary',
    'navbar-secondary',
    'navbar-info',
    'navbar-success',
    'navbar-danger',
    'navbar-indigo',
    'navbar-purple',
    'navbar-pink',
    'navbar-navy',
    'navbar-lightblue',
    'navbar-teal',
    'navbar-cyan',
    'navbar-dark',
    'navbar-gray-dark',
    'navbar-gray'
  ]

  var navbar_light_skins = [
    'navbar-light',
    'navbar-warning',
    'navbar-white',
    'navbar-orange'
  ]

  var sIdebar_colors = [
    'bg-primary',
    'bg-warning',
    'bg-info',
    'bg-danger',
    'bg-success',
    'bg-indigo',
    'bg-lightblue',
    'bg-navy',
    'bg-purple',
    'bg-fuchsia',
    'bg-pink',
    'bg-maroon',
    'bg-orange',
    'bg-lime',
    'bg-teal',
    'bg-olive'
  ]

  var accent_colors = [
    'accent-primary',
    'accent-warning',
    'accent-info',
    'accent-danger',
    'accent-success',
    'accent-indigo',
    'accent-lightblue',
    'accent-navy',
    'accent-purple',
    'accent-fuchsia',
    'accent-pink',
    'accent-maroon',
    'accent-orange',
    'accent-lime',
    'accent-teal',
    'accent-olive'
  ]

  var sIdebar_skins = [
    'sIdebar-dark-primary',
    'sIdebar-dark-warning',
    'sIdebar-dark-info',
    'sIdebar-dark-danger',
    'sIdebar-dark-success',
    'sIdebar-dark-indigo',
    'sIdebar-dark-lightblue',
    'sIdebar-dark-navy',
    'sIdebar-dark-purple',
    'sIdebar-dark-fuchsia',
    'sIdebar-dark-pink',
    'sIdebar-dark-maroon',
    'sIdebar-dark-orange',
    'sIdebar-dark-lime',
    'sIdebar-dark-teal',
    'sIdebar-dark-olive',
    'sIdebar-light-primary',
    'sIdebar-light-warning',
    'sIdebar-light-info',
    'sIdebar-light-danger',
    'sIdebar-light-success',
    'sIdebar-light-indigo',
    'sIdebar-light-lightblue',
    'sIdebar-light-navy',
    'sIdebar-light-purple',
    'sIdebar-light-fuchsia',
    'sIdebar-light-pink',
    'sIdebar-light-maroon',
    'sIdebar-light-orange',
    'sIdebar-light-lime',
    'sIdebar-light-teal',
    'sIdebar-light-olive'
  ]

  // Navbar Variants

  $container.append('<h6>Navbar Variants</h6>')

  var $navbar_variants = $('<div />', {
    class: 'd-flex'
  })
  var navbar_all_colors = navbar_dark_skins.concat(navbar_light_skins)
  var $navbar_variants_colors = createSkinBlock(navbar_all_colors, function () {
    var color = $(this).find('option:selected').attr('class')
    var $main_header = $('.main-header')
    $main_header.removeClass('navbar-dark').removeClass('navbar-light')
    navbar_all_colors.forEach(function (color) {
      $main_header.removeClass(color)
    })

    $(this).removeClass().addClass('custom-select mb-3 text-light border-0 ')

    if (navbar_dark_skins.indexOf(color) > -1) {
      $main_header.addClass('navbar-dark')
      $(this).addClass(color).addClass('text-light')
    } else {
      $main_header.addClass('navbar-light')
      $(this).addClass(color)
    }

    $main_header.addClass(color)
  })

  var active_navbar_color = null
  $('.main-header')[0].classList.forEach(function (className) {
    if (navbar_all_colors.indexOf(className) > -1 && active_navbar_color === null) {
      active_navbar_color = className.replace('navbar-', 'bg-')
    }
  })

  $navbar_variants_colors.find('option.' + active_navbar_color).prop('selected', true)
  $navbar_variants_colors.removeClass().addClass('custom-select mb-3 text-light border-0 ').addClass(active_navbar_color)

  $navbar_variants.append($navbar_variants_colors)

  $container.append($navbar_variants)

  // SIdebar Colors

  $container.append('<h6>Accent Color Variants</h6>')
  var $accent_variants = $('<div />', {
    class: 'd-flex'
  })
  $container.append($accent_variants)
  $container.append(createSkinBlock(accent_colors, function () {
    var color = $(this).find('option:selected').attr('class')
    var $body = $('body')
    accent_colors.forEach(function (skin) {
      $body.removeClass(skin)
    })

    var accent_color_class = color.replace('bg-', 'accent-')

    $body.addClass(accent_color_class)
  }, true))

  var active_accent_color = null
  $('body')[0].classList.forEach(function (className) {
    if (accent_colors.indexOf(className) > -1 && active_accent_color === null) {
      active_accent_color = className.replace('navbar-', 'bg-')
    }
  })

  // $accent_variants.find('option.' + active_accent_color).prop('selected', true)
  // $accent_variants.removeClass().addClass('custom-select mb-3 text-light border-0 ').addClass(active_accent_color)

  $container.append('<h6>Dark SIdebar Variants</h6>')
  var $sIdebar_variants_dark = $('<div />', {
    class: 'd-flex'
  })
  $container.append($sIdebar_variants_dark)
  var $sIdebar_dark_variants = createSkinBlock(sIdebar_colors, function () {
    var color = $(this).find('option:selected').attr('class')
    var sIdebar_class = 'sIdebar-dark-' + color.replace('bg-', '')
    var $sIdebar = $('.main-sIdebar')
    sIdebar_skins.forEach(function (skin) {
      $sIdebar.removeClass(skin)
      $sIdebar_light_variants.removeClass(skin.replace('sIdebar-dark-', 'bg-')).removeClass('text-light')
    })

    $(this).removeClass().addClass('custom-select mb-3 text-light border-0').addClass(color)

    $sIdebar_light_variants.find('option').prop('selected', false)
    $sIdebar.addClass(sIdebar_class)
    $('.sIdebar').removeClass('os-theme-dark').addClass('os-theme-light')
  }, true)
  $container.append($sIdebar_dark_variants)

  var active_sIdebar_dark_color = null
  $('.main-sIdebar')[0].classList.forEach(function (className) {
    var color = className.replace('sIdebar-dark-', 'bg-')
    if (sIdebar_colors.indexOf(color) > -1 && active_sIdebar_dark_color === null) {
      active_sIdebar_dark_color = color
    }
  })

  $sIdebar_dark_variants.find('option.' + active_sIdebar_dark_color).prop('selected', true)
  $sIdebar_dark_variants.removeClass().addClass('custom-select mb-3 text-light border-0 ').addClass(active_sIdebar_dark_color)

  $container.append('<h6>Light SIdebar Variants</h6>')
  var $sIdebar_variants_light = $('<div />', {
    class: 'd-flex'
  })
  $container.append($sIdebar_variants_light)
  var $sIdebar_light_variants = createSkinBlock(sIdebar_colors, function () {
    var color = $(this).find('option:selected').attr('class')
    var sIdebar_class = 'sIdebar-light-' + color.replace('bg-', '')
    var $sIdebar = $('.main-sIdebar')
    sIdebar_skins.forEach(function (skin) {
      $sIdebar.removeClass(skin)
      $sIdebar_dark_variants.removeClass(skin.replace('sIdebar-light-', 'bg-')).removeClass('text-light')
    })

    $(this).removeClass().addClass('custom-select mb-3 text-light border-0').addClass(color)

    $sIdebar_dark_variants.find('option').prop('selected', false)
    $sIdebar.addClass(sIdebar_class)
    $('.sIdebar').removeClass('os-theme-light').addClass('os-theme-dark')
  }, true)
  $container.append($sIdebar_light_variants)

  var active_sIdebar_light_color = null
  $('.main-sIdebar')[0].classList.forEach(function (className) {
    var color = className.replace('sIdebar-light-', 'bg-')
    if (sIdebar_colors.indexOf(color) > -1 && active_sIdebar_light_color === null) {
      active_sIdebar_light_color = color
    }
  })

  if (active_sIdebar_light_color !== null) {
    $sIdebar_light_variants.find('option.' + active_sIdebar_light_color).prop('selected', true)
    $sIdebar_light_variants.removeClass().addClass('custom-select mb-3 text-light border-0 ').addClass(active_sIdebar_light_color)
  }

  var logo_skins = navbar_all_colors
  $container.append('<h6>Brand Logo Variants</h6>')
  var $logo_variants = $('<div />', {
    class: 'd-flex'
  })
  $container.append($logo_variants)
  var $clear_btn = $('<a />', {
    href: '#'
  }).text('clear').on('click', function (e) {
    e.preventDefault()
    var $logo = $('.brand-link')
    logo_skins.forEach(function (skin) {
      $logo.removeClass(skin)
    })
  })

  var $brand_variants = createSkinBlock(logo_skins, function () {
    var color = $(this).find('option:selected').attr('class')
    var $logo = $('.brand-link')

    if (color === 'navbar-light' || color === 'navbar-white') {
      $logo.addClass('text-black')
    } else {
      $logo.removeClass('text-black')
    }

    logo_skins.forEach(function (skin) {
      $logo.removeClass(skin)
    })

    if (color) {
      $(this).removeClass().addClass('custom-select mb-3 border-0').addClass(color).addClass(color !== 'navbar-light' && color !== 'navbar-white' ? 'text-light' : '')
    } else {
      $(this).removeClass().addClass('custom-select mb-3 border-0')
    }

    $logo.addClass(color)
  }, true).append($clear_btn)
  $container.append($brand_variants)

  var active_brand_color = null
  $('.brand-link')[0].classList.forEach(function (className) {
    if (logo_skins.indexOf(className) > -1 && active_brand_color === null) {
      active_brand_color = className.replace('navbar-', 'bg-')
    }
  })

  if (active_brand_color) {
    $brand_variants.find('option.' + active_brand_color).prop('selected', true)
    $brand_variants.removeClass().addClass('custom-select mb-3 text-light border-0 ').addClass(active_brand_color)
  }
})(jQuery)
