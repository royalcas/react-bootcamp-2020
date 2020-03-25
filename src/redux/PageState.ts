export type PageState<PageData> = {
  isLoading: boolean;
  hasErrors: boolean;
  pageData: PageData;
};
