<template>
  <div>
    <h1>Billetter og setereservasjon</h1>
    <p>Her finner du informasjon om blant annet hvordan du kjøper våre forskjellige billetter, hvordan du reserverer sete eller sovekupé og hvordan vi samarbeider med lokale operatører.</p>
    <div class="faqs">
      <div
        :class="{'qa_container': true, 'last':index===faqModels.length-1}"
        v-for="(item, index) in faqModels"
        :key="index"
      >
        <div class="q_container clickable" @click="toggle(index)">
          {{item.question}}
          <span class="like_info">
            {{item.likes}}
            <img src="../assets/like-icon.png" alt="like" width="12" />
            {{item.dislikes}}
            <img
              src="../assets/dislike-icon.png"
              alt="like"
              width="12"
            />
          </span>
        </div>
        <div class="a_container" v-show="activeIndexes[index]">
          {{item.answer}}
          <div class="like_buttons">
            <p>Var dette svaret nyttig?</p>
            <div v-if="!thankyouforvoting[index]">
              <div @click="like(index)" class="clickable flex_container">
                <img src="../assets/upvote.png" alt="upvote" width="32" />
                <span>JA</span>
              </div>
              <div @click="dislike(index)" class="clickable flex_container">
                <img src="../assets/downvote.png" alt="upvote" width="32" />
                <span>NEI</span>
              </div>
            </div>
            <div v-else>
              <p class="feedback">Takk for tilbakemeldingen.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      faqModels: [],
      activeIndexes: [],
      thankyouforvoting: []
    };
  },
  mounted() {
    let comp = this;
    fetch("/api/Faqs/", {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8"
      }
    })
      .then(resp => resp.json())
      .then(data => {
        comp.faqModels = data;
      });
  },
  methods: {
    toggle(index) {
      this.$set(this.activeIndexes, index, !this.activeIndexes[index]);
    },
    like(index) {
      let comp = this;
      let faq = comp.faqModels[index];
      faq.likes++;
      comp.patchFaq(faq);
      comp.thankyouforvoting[index] = true;
    },
    dislike(index) {
      let comp = this;
      let faq = comp.faqModels[index];
      faq.dislikes++;
      comp.patchFaq(faq);
      comp.thankyouforvoting[index] = true;
    },
    patchFaq(faq) {
      fetch("/api/Faqs/" + faq.id, {
        method: "PATCH",
        body: JSON.stringify(faq),
        headers: {
          "Content-type": "application/json; charset=UTF-8"
        }
      })
        .then(res => {
          window.console.log(res);
        })
        .catch(res => {
          window.console.log(res);
        });
    }
  }
};
</script>

<style>
.qa_container {
  border-top: 1px solid black;
  padding: 10px;
}

.qa_container.last {
  border-bottom: 1px solid black;
}

.q_container {
  font-size: 16px;
  font-weight: bold;
  cursor: pointer;
}

.clickable {
  cursor: pointer;
}

.a_container {
  font-size: 16px;
  padding-top: 20px;
  padding-bottom: 20px;
}

.faqs,
.like_buttons {
  padding-top: 40px;
}

.like_buttons img {
  margin: 10px 10px 0 0;
}

.like_info {
  float: right;
  font-weight: normal;
}

.like_info img {
  margin-right: 15px;
}

.feedback {
  color: gray;
}

.flex_container {
  display: flex;
  align-items: center;
}
</style>