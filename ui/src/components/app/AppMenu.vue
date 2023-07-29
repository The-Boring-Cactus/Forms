<script setup >
import AppSubmenu from './AppSubmenu.vue'
defineProps({
    model: Array,
})
const emit = defineEmits(['menuItemClick'])

function onmenuItemClick(event) {
  emit('menuItemClick', event)
}
</script>

<template>
    <div class="layout-menu-container">
      <AppSubmenu :items="model" class="layout-menu" :root="true" @menu-item-click="onmenuItemClick" />
    </div>
  </template>
  
  <style scoped>
  </style>