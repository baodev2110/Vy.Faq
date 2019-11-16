<template>
  <div class="menu_container">
    <div>
      <img class="logo" src="../assets/logo.png" width="110" />
    </div>
    <div>
      <nav>
        <a
          href="#"
          v-for="(item, index) in items"
          :key="index"
          @click="activeIndex = index"
        >{{item}}</a>
      </nav>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    items: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      activeIndex: 0
    };
  }
};
</script>

<style>
a {
  text-decoration: none;
  color: black;
  padding: 0 20px 0 20px;
}
.menu_container{
  display:flex;
  align-items:center;
}
</style>