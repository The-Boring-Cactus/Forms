import { defineStore } from 'pinia'

export function updateTheme(themeName, themeColor) {
  const newValue = `/themes/${themeName}-${themeColor}/theme.css`
  console.log(newValue)
  const relElement = document.getElementById('themelink')
  console.log(relElement)
  relElement.setAttribute('href', newValue)
}

// main is the name of the store. It is unique across your application
// and will appear in devtools
export const useThemeStore = defineStore('theme', {
  // a function that returns a fresh state
  state: () => ({
    themeName: 'saga',
    themeColor: 'blue',
  }),
  // optional getters
  getters: {
    theme: (state) => {
      return `${state.themeName}-${state.themeColor}`
    },
    isDarkMode: state => state.themeName !== 'saga',
  },
  // optional actions
  actions: {
    setDark() {
      this.themeName = 'arya'
      updateTheme(this.themeName, this.themeColor)
    },
    setDim() {
      this.themeName = 'vela'
      updateTheme(this.themeName, this.themeColor)
    },
    setLight() {
      this.themeName = 'saga'
      updateTheme(this.themeName, this.themeColor)
    },
    setColor(colorName) {
      this.themeColor = colorName
      updateTheme(this.themeName, this.themeColor)
    },
  },
})