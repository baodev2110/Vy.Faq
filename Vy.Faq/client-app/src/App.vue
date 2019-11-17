<template>
  <div id="app">
    <Menu
      class="menu"
      :selectedItem="selectedItem"
      :items="['Spørsmål og svar', 'Kontakt oss']"
      @change="selectItem"
    />
    <div class="content">
      <Faq v-if="selectedItem === 0" />
      <Contact v-if="selectedItem === 1" />
    </div>
  </div>
</template>

<script>
import Menu from "./components/Menu.vue";
import Faq from "./components/Faq.vue";
import Contact from "./components/Contact.vue";

export default {
  name: "app",
  components: {
    Menu,
    Faq,
    Contact
  },
  data() {
    return {
      selectedItem: 0
    };
  },
  methods: {
    selectItem(index) {
      this.selectedItem = index;
    }
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
  padding-top: 40px;
  width: 50%;
}
</style>
