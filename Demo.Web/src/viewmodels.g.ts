import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface AuthorViewModel extends $models.Author {
  authorId: number | null;
  name: string | null;
  books: BookViewModel[] | null;
}
export class AuthorViewModel extends ViewModel<$models.Author, $apiClients.AuthorApiClient, number> implements $models.Author  {
  
  
  public addToBooks(initialData?: DeepPartial<$models.Book> | null) {
    return this.$addChild('books', initialData) as BookViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Author> | null) {
    super($metadata.Author, new $apiClients.AuthorApiClient(), initialData)
  }
}
defineProps(AuthorViewModel, $metadata.Author)

export class AuthorListViewModel extends ListViewModel<$models.Author, $apiClients.AuthorApiClient, AuthorViewModel> {
  
  constructor() {
    super($metadata.Author, new $apiClients.AuthorApiClient())
  }
}


export interface BookViewModel extends $models.Book {
  bookId: number | null;
  title: string | null;
  description: string | null;
  publishDate: Date | null;
  authorId: number | null;
  author: AuthorViewModel | null;
}
export class BookViewModel extends ViewModel<$models.Book, $apiClients.BookApiClient, number> implements $models.Book  {
  
  constructor(initialData?: DeepPartial<$models.Book> | null) {
    super($metadata.Book, new $apiClients.BookApiClient(), initialData)
  }
}
defineProps(BookViewModel, $metadata.Book)

export class BookListViewModel extends ListViewModel<$models.Book, $apiClients.BookApiClient, BookViewModel> {
  
  constructor() {
    super($metadata.Book, new $apiClients.BookApiClient())
  }
}


export interface WidgetViewModel extends $models.Widget {
  widgetId: number | null;
  name: string | null;
  category: $models.WidgetCategory | null;
  inventedOn: Date | null;
}
export class WidgetViewModel extends ViewModel<$models.Widget, $apiClients.WidgetApiClient, number> implements $models.Widget  {
  
  constructor(initialData?: DeepPartial<$models.Widget> | null) {
    super($metadata.Widget, new $apiClients.WidgetApiClient(), initialData)
  }
}
defineProps(WidgetViewModel, $metadata.Widget)

export class WidgetListViewModel extends ListViewModel<$models.Widget, $apiClients.WidgetApiClient, WidgetViewModel> {
  
  constructor() {
    super($metadata.Widget, new $apiClients.WidgetApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Author: AuthorViewModel,
  Book: BookViewModel,
  Widget: WidgetViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Author: AuthorListViewModel,
  Book: BookListViewModel,
  Widget: WidgetListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

