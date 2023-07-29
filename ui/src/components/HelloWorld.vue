<script setup>
import { ref } from 'vue'

defineProps({
  msg: String,
})

const count = ref(0)
</script>

<template>
  <h1>{{ msg }}</h1>

  <div class="flex flex-column md:flex-row md:justify-content-between row-gap-3">
    <Button type="button" label="Button 1"></Button>
    <Button type="button" label="Button 2" severity="secondary"></Button>
    <Button type="button" label="Button 3" severity="help"></Button>
</div>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
