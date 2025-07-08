import { IPOCTemplatePage } from './app.po';

describe('IPOC App', function() {
  let page: IPOCTemplatePage;

  beforeEach(() => {
    page = new IPOCTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
