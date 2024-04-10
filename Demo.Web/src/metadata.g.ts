import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const WidgetCategory = domain.enums.WidgetCategory = {
  name: "WidgetCategory",
  displayName: "Widget Category",
  type: "enum",
  ...getEnumMeta<"Whizbangs"|"Sprecklesprockets"|"Discombobulators">([
  {
    value: 0,
    strValue: "Whizbangs",
    displayName: "Whizbangs",
  },
  {
    value: 1,
    strValue: "Sprecklesprockets",
    displayName: "Sprecklesprockets",
  },
  {
    value: 2,
    strValue: "Discombobulators",
    displayName: "Discombobulators",
  },
  ]),
}
export const Author = domain.types.Author = {
  name: "Author",
  displayName: "Author",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Author",
  get keyProp() { return this.props.authorId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    authorId: {
      name: "authorId",
      displayName: "Author Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    books: {
      name: "books",
      displayName: "Books",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Book as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Book as ModelType).props.authorId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Book as ModelType).props.author as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    authorDataSource: {
      type: "dataSource",
      name: "AuthorDataSource",
      displayName: "Author Data Source",
      props: {
      },
    },
  },
}
export const Book = domain.types.Book = {
  name: "Book",
  displayName: "Book",
  get displayProp() { return this.props.bookId }, 
  type: "model",
  controllerRoute: "Book",
  get keyProp() { return this.props.bookId }, 
  behaviorFlags: 3 as BehaviorFlags,
  props: {
    bookId: {
      name: "bookId",
      displayName: "Book Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    title: {
      name: "title",
      displayName: "Title",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Title is required.",
      }
    },
    description: {
      name: "description",
      displayName: "Description",
      type: "string",
      role: "value",
    },
    publishDate: {
      name: "publishDate",
      displayName: "Publish Date",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
    },
    authorId: {
      name: "authorId",
      displayName: "Author Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Author as ModelType).props.authorId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Author as ModelType) },
      get navigationProp() { return (domain.types.Book as ModelType).props.author as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => val != null || "Author is required.",
      }
    },
    author: {
      name: "author",
      displayName: "Author",
      type: "model",
      get typeDef() { return (domain.types.Author as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Book as ModelType).props.authorId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Author as ModelType).props.authorId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Author as ModelType).props.books as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Widget = domain.types.Widget = {
  name: "Widget",
  displayName: "Widget",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Widget",
  get keyProp() { return this.props.widgetId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    widgetId: {
      name: "widgetId",
      displayName: "Widget Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    category: {
      name: "category",
      displayName: "Category",
      type: "enum",
      get typeDef() { return domain.enums.WidgetCategory },
      role: "value",
      rules: {
        required: val => val != null || "Category is required.",
      }
    },
    inventedOn: {
      name: "inventedOn",
      displayName: "Invented On",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}

interface AppDomain extends Domain {
  enums: {
    WidgetCategory: typeof WidgetCategory
  }
  types: {
    Author: typeof Author
    Book: typeof Book
    Widget: typeof Widget
  }
  services: {
  }
}

solidify(domain)

export default domain as unknown as AppDomain
