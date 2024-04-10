import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosPromise, AxiosRequestConfig, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'

export class AuthorApiClient extends ModelApiClient<$models.Author> {
  constructor() { super($metadata.Author) }
}


export class BookApiClient extends ModelApiClient<$models.Book> {
  constructor() { super($metadata.Book) }
}


export class WidgetApiClient extends ModelApiClient<$models.Widget> {
  constructor() { super($metadata.Widget) }
}


