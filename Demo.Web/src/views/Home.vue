<template>
  <div class="home">
    <v-list>
      <v-list-item v-for="author in authors.$items" :key="author.authorId!">
        {{ author.name }}
        <ul>
          <li v-for="book in author.books" :key="book.bookId!" cols="3">
            {{ book.title }} : {{ book.description }}
          </li>
        </ul>
      </v-list-item>
    </v-list>
    <c-list-pagination :list="authors" />
  </div>
</template>

<script setup lang="ts">
import { AuthorListViewModel } from "@/viewmodels.g";
import { Author } from "@/models.g";

useTitle("Home");

const authors = new AuthorListViewModel();
authors.$dataSource = new Author.DataSources.AuthorDataSource();

authors.$load();
authors.$useAutoLoad();
</script>
