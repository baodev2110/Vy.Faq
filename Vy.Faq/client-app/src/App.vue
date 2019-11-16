<template>
  <div id="app">
    <Menu class="menu" :items="['Spørsmål og svar', 'Kontakt oss']" />
    <div class="content">
      <Faq />
    </div>
  </div>
</template>

<script>
import Menu from "./components/Menu.vue";
import Faq from "./components/Faq.vue";

export default {
  name: "app",
  components: {
    Menu,
    Faq
  }
};
</script>

<style>
@font-face {
  font-family: "PublicSans";
  src: url("./assets/PublicSans.ttf");
}

* {
  font-family: "PublicSans";
}

#app {
  padding: 40px;
}

.content {
  padding: 40px;
}

</style>
