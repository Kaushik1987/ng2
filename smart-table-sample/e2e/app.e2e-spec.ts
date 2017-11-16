import { SmartTableSamplePage } from './app.po';

describe('smart-table-sample App', function() {
  let page: SmartTableSamplePage;

  beforeEach(() => {
    page = new SmartTableSamplePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
