<script setup>

import { ref } from 'vue';
defineProps({
    items: Array
})

const emit = defineEmits(['menuItemClick'])

const activeIndex = ref(null)

function onmenuItemClick(event, item, index) {
  if (item.command)
    item.command({ originalEvent: event, item })
  emit('menuItemClick', {
    originalEvent: event,
    item,
  })
}


</script>

<template>
    <ul class="layout-menu">
      <template v-for="(item, i) of items">
        <li
          v-if="item.separator" class="p-menu-separator" 
          role="separator"
        />
        <li v-else
          
          class
          role="none"
        >
         <a
              class="p-ripplerouter-link-active  p-ripple" 
              exact role="menuitem" @click="onmenuItemClick($event, item, i)"
            >
              <i :class="item.icon" />
              <span>{{ item.label }}</span>
            </a>
        </li>
      </template>
    </ul>
  </template>
  
  <style scoped>
  </style>