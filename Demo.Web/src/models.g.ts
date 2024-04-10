import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export enum WidgetCategory {
  Whizbangs = 0,
  Sprecklesprockets = 1,
  Discombobulators = 2,
}


export interface Author extends Model<typeof metadata.Author> {
  authorId: number | null
  name: string | null
  books: Book[] | null
}
export class Author {
  
  /** Mutates the input object and its descendents into a valid Author implementation. */
  static convert(data?: Partial<Author>): Author {
    return convertToModel(data || {}, metadata.Author) 
  }
  
  /** Maps the input object and its descendents to a new, valid Author implementation. */
  static map(data?: Partial<Author>): Author {
    return mapToModel(data || {}, metadata.Author) 
  }
  
  /** Instantiate a new Author, optionally basing it on the given data. */
  constructor(data?: Partial<Author> | {[k: string]: any}) {
    Object.assign(this, Author.map(data || {}));
  }
}
export namespace Author {
  export namespace DataSources {
    
    export class AuthorDataSource implements DataSource<typeof metadata.Author.dataSources.authorDataSource> {
      readonly $metadata = metadata.Author.dataSources.authorDataSource
    }
  }
}


export interface Book extends Model<typeof metadata.Book> {
  bookId: number | null
  title: string | null
  description: string | null
  publishDate: Date | null
  authorId: number | null
  author: Author | null
}
export class Book {
  
  /** Mutates the input object and its descendents into a valid Book implementation. */
  static convert(data?: Partial<Book>): Book {
    return convertToModel(data || {}, metadata.Book) 
  }
  
  /** Maps the input object and its descendents to a new, valid Book implementation. */
  static map(data?: Partial<Book>): Book {
    return mapToModel(data || {}, metadata.Book) 
  }
  
  /** Instantiate a new Book, optionally basing it on the given data. */
  constructor(data?: Partial<Book> | {[k: string]: any}) {
    Object.assign(this, Book.map(data || {}));
  }
}


export interface Widget extends Model<typeof metadata.Widget> {
  widgetId: number | null
  name: string | null
  category: WidgetCategory | null
  inventedOn: Date | null
}
export class Widget {
  
  /** Mutates the input object and its descendents into a valid Widget implementation. */
  static convert(data?: Partial<Widget>): Widget {
    return convertToModel(data || {}, metadata.Widget) 
  }
  
  /** Maps the input object and its descendents to a new, valid Widget implementation. */
  static map(data?: Partial<Widget>): Widget {
    return mapToModel(data || {}, metadata.Widget) 
  }
  
  /** Instantiate a new Widget, optionally basing it on the given data. */
  constructor(data?: Partial<Widget> | {[k: string]: any}) {
    Object.assign(this, Widget.map(data || {}));
  }
}


