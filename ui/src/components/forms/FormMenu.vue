<script setup >
import FormSubmenu from './FormSubmenu.vue'
defineProps({
    model: Array,
})
const emit = defineEmits(['menuItemClick'])

function onmenuItemClick(event,  item) {
  emit('menuItemClick', {event,  item})
}
</script>

<template>
    <div class="layout-menu-container">
      <FormSubmenu :items="model" class="layout-menu"  @menu-item-click="onmenuItemClick" />
    </div>
  </template>
  
  <style scoped>
  </style>