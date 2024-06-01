/**
 * --------------------------------------------
 * AdminLTE Layout.js
 * License MIT
 * --------------------------------------------
 */

import $ from 'jquery'

/**
 * Constants
 * ====================================================
 */

const NAME = 'Layout'
const DATA_KEY = 'lte.layout'
const JQUERY_NO_CONFLICT = $.fn[NAME]

const SELECTOR_HEADER = '.main-header'
const SELECTOR_MAIN_SIdEBAR = '.main-sIdebar'
const SELECTOR_SIdEBAR = '.main-sIdebar .sIdebar'
const SELECTOR_CONTENT = '.content-wrapper'
const SELECTOR_CONTROL_SIdEBAR_CONTENT = '.control-sIdebar-content'
const SELECTOR_CONTROL_SIdEBAR_BTN = '[data-wIdget="control-sIdebar"]'
const SELECTOR_FOOTER = '.main-footer'
const SELECTOR_PUSHMENU_BTN = '[data-wIdget="pushmenu"]'
const SELECTOR_LOGIN_BOX = '.login-box'
const SELECTOR_REGISTER_BOX = '.register-box'
const SELECTOR_PRELOADER = '.preloader'

const CLASS_NAME_SIdEBAR_COLLAPSED = 'sIdebar-collapse'
const CLASS_NAME_SIdEBAR_FOCUSED = 'sIdebar-focused'
const CLASS_NAME_LAYOUT_FIXED = 'layout-fixed'
const CLASS_NAME_CONTROL_SIdEBAR_SLIdE_OPEN = 'control-sIdebar-slIde-open'
const CLASS_NAME_CONTROL_SIdEBAR_OPEN = 'control-sIdebar-open'
const CLASS_NAME_IFRAME_MODE = 'iframe-mode'

const Default = {
  scrollbarTheme: 'os-theme-light',
  scrollbarAutoHIde: 'l',
  panelAutoHeight: true,
  panelAutoHeightMode: 'min-height',
  preloadDuration: 200,
  loginRegisterAutoHeight: true
}

/**
 * Class Definition
 * ====================================================
 */

class Layout {
  constructor(element, config) {
    this._config = config
    this._element = element
  }

  // Public

  fixLayoutHeight(extra = null) {
    const $body = $('body')
    let controlSIdebar = 0

    if ($body.hasClass(CLASS_NAME_CONTROL_SIdEBAR_SLIdE_OPEN) || $body.hasClass(CLASS_NAME_CONTROL_SIdEBAR_OPEN) || extra === 'control_sIdebar') {
      controlSIdebar = $(SELECTOR_CONTROL_SIdEBAR_CONTENT).outerHeight()
    }

    const heights = {
      window: $(window).height(),
      header: $(SELECTOR_HEADER).length > 0 ? $(SELECTOR_HEADER).outerHeight() : 0,
      footer: $(SELECTOR_FOOTER).length > 0 ? $(SELECTOR_FOOTER).outerHeight() : 0,
      sIdebar: $(SELECTOR_SIdEBAR).length > 0 ? $(SELECTOR_SIdEBAR).height() : 0,
      controlSIdebar
    }

    const max = this._max(heights)
    let offset = this._config.panelAutoHeight

    if (offset === true) {
      offset = 0
    }

    const $contentSelector = $(SELECTOR_CONTENT)

    if (offset !== false) {
      if (max === heights.controlSIdebar) {
        $contentSelector.css(this._config.panelAutoHeightMode, (max + offset))
      } else if (max === heights.window) {
        $contentSelector.css(this._config.panelAutoHeightMode, (max + offset) - heights.header - heights.footer)
      } else {
        $contentSelector.css(this._config.panelAutoHeightMode, (max + offset) - heights.header)
      }

      if (this._isFooterFixed()) {
        $contentSelector.css(this._config.panelAutoHeightMode, parseFloat($contentSelector.css(this._config.panelAutoHeightMode)) + heights.footer)
      }
    }

    if (!$body.hasClass(CLASS_NAME_LAYOUT_FIXED)) {
      return
    }

    if (typeof $.fn.overlayScrollbars !== 'undefined') {
      $(SELECTOR_SIdEBAR).overlayScrollbars({
        className: this._config.scrollbarTheme,
        sizeAutoCapable: true,
        scrollbars: {
          autoHIde: this._config.scrollbarAutoHIde,
          clickScrolling: true
        }
      })
    } else {
      $(SELECTOR_SIdEBAR).css('overflow-y', 'auto')
    }
  }

  fixLoginRegisterHeight() {
    const $body = $('body')
    const $selector = $(`${SELECTOR_LOGIN_BOX}, ${SELECTOR_REGISTER_BOX}`)

    if ($body.hasClass(CLASS_NAME_IFRAME_MODE)) {
      $body.css('height', '100%')
      $('.wrapper').css('height', '100%')
      $('html').css('height', '100%')
    } else if ($selector.length === 0) {
      $body.css('height', 'auto')
      $('html').css('height', 'auto')
    } else {
      const boxHeight = $selector.height()

      if ($body.css(this._config.panelAutoHeightMode) !== boxHeight) {
        $body.css(this._config.panelAutoHeightMode, boxHeight)
      }
    }
  }

  // Private

  _init() {
    // Activate layout height watcher
    this.fixLayoutHeight()

    if (this._config.loginRegisterAutoHeight === true) {
      this.fixLoginRegisterHeight()
    } else if (this._config.loginRegisterAutoHeight === parseInt(this._config.loginRegisterAutoHeight, 10)) {
      setInterval(this.fixLoginRegisterHeight, this._config.loginRegisterAutoHeight)
    }

    $(SELECTOR_SIdEBAR)
      .on('collapsed.lte.treeview expanded.lte.treeview', () => {
        this.fixLayoutHeight()
      })

    $(SELECTOR_MAIN_SIdEBAR)
      .on('mouseenter mouseleave', () => {
        if ($('body').hasClass(CLASS_NAME_SIdEBAR_COLLAPSED)) {
          this.fixLayoutHeight()
        }
      })

    $(SELECTOR_PUSHMENU_BTN)
      .on('collapsed.lte.pushmenu shown.lte.pushmenu', () => {
        setTimeout(() => {
          this.fixLayoutHeight()
        }, 300)
      })

    $(SELECTOR_CONTROL_SIdEBAR_BTN)
      .on('collapsed.lte.controlsIdebar', () => {
        this.fixLayoutHeight()
      })
      .on('expanded.lte.controlsIdebar', () => {
        this.fixLayoutHeight('control_sIdebar')
      })

    $(window).resize(() => {
      this.fixLayoutHeight()
    })

    setTimeout(() => {
      $('body.hold-transition').removeClass('hold-transition')
    }, 50)

    setTimeout(() => {
      const $preloader = $(SELECTOR_PRELOADER)
      if ($preloader) {
        $preloader.css('height', 0)
        setTimeout(() => {
          $preloader.children().hIde()
        }, 200)
      }
    }, this._config.preloadDuration)
  }

  _max(numbers) {
    // Calculate the maximum number in a list
    let max = 0

    Object.keys(numbers).forEach(key => {
      if (numbers[key] > max) {
        max = numbers[key]
      }
    })

    return max
  }

  _isFooterFixed() {
    return $(SELECTOR_FOOTER).css('position') === 'fixed'
  }

  // Static

  static _jQueryInterface(config = '') {
    return this.each(function () {
      let data = $(this).data(DATA_KEY)
      const _options = $.extend({}, Default, $(this).data())

      if (!data) {
        data = new Layout($(this), _options)
        $(this).data(DATA_KEY, data)
      }

      if (config === 'init' || config === '') {
        data._init()
      } else if (config === 'fixLayoutHeight' || config === 'fixLoginRegisterHeight') {
        data[config]()
      }
    })
  }
}

/**
 * Data API
 * ====================================================
 */

$(window).on('load', () => {
  Layout._jQueryInterface.call($('body'))
})

$(`${SELECTOR_SIdEBAR} a`)
  .on('focusin', () => {
    $(SELECTOR_MAIN_SIdEBAR).addClass(CLASS_NAME_SIdEBAR_FOCUSED)
  })
  .on('focusout', () => {
    $(SELECTOR_MAIN_SIdEBAR).removeClass(CLASS_NAME_SIdEBAR_FOCUSED)
  })

/**
 * jQuery API
 * ====================================================
 */

$.fn[NAME] = Layout._jQueryInterface
$.fn[NAME].Constructor = Layout
$.fn[NAME].noConflict = function () {
  $.fn[NAME] = JQUERY_NO_CONFLICT
  return Layout._jQueryInterface
}

export default Layout
