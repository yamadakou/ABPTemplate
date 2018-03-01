import { ABPTemplateTemplatePage } from './app.po';

describe('ABPTemplate App', function() {
  let page: ABPTemplateTemplatePage;

  beforeEach(() => {
    page = new ABPTemplateTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
