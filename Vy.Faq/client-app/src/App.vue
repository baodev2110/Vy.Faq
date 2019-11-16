<template>
  <div id="app">
    <Menu />
    <Faq />
  </div>
  
</template>

<script>
import Menu from './components/Menu.vue'
import Faq from './components/Faq.vue'

export default {
  name: 'app',
  components: {
    Menu,
    Faq
  }
}
</script>
