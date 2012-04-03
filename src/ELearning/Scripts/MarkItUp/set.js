// -------------------------------------------------------------------
// markItUp!
// -------------------------------------------------------------------
// Copyright (C) 2008 Jay Salvat
// http://markitup.jaysalvat.com/
// -------------------------------------------------------------------

mySettings = {
    previewParserPath: '',
    onShiftEnter: { keepDefault: false, replaceWith: '\n\n' },
    markupSet: [
		{ name: 'Heading 1', key: '1', openWith: '|H1 ', closeWith: '\n', placeHolder: 'Text' },
		{ name: 'Heading 2', key: '2', openWith: '|H2 ', closeWith: '\n', placeHolder: 'Text' },
        { name: 'Heading 3', key: '3', openWith: '|H3 ', closeWith: '\n', placeHolder: 'Text' },
        { name: 'Heading 4', key: '4', openWith: '|H4 ', closeWith: '\n', placeHolder: 'Text' },
        { name: 'Heading 5', key: '5', openWith: '|H5 ', closeWith: '\n', placeHolder: 'Text' },
//        { name: 'Heading 6', key: '6', openWith: '|H6 ', closeWith: '\n', placeHolder: 'Text' },
		{ separator: '---------------' },
		{ name: 'Bold', key: 'B', openWith: '[B:', closeWith: ']' },
		{ name: 'Italic', key: 'I', openWith: '[I:', closeWith: ']' },
        { name: 'Underline', key: 'U', openWith: '[U:', closeWith: ']' },
		{ name: 'Stroke', key: 'S', openWith: '[S:', closeWith: ']' },
		{ separator: '---------------' },
		{ name: 'Bulleted list', openWith: '(!(* |!|*)!)' },
		{ name: 'Numeric list', openWith: '(!(# |!|#)!)' },
		{ separator: '---------------' },
		{ name: 'Picture', key: "P", replaceWith: '[[Image:[![Url:!:http://]!]|[![name]!]]]' },
		{ name: 'Link', key: "L", openWith: "[[![Link]!] ", closeWith: ']', placeHolder: 'Your text to link here...' },
		{ name: 'Url', openWith: "[[![Url:!:http://]!] ", closeWith: ']', placeHolder: 'Your text to link here...' },
		{ separator: '---------------' },
		{ name: 'Quotes', openWith: '(!(> |!|>)!)', placeHolder: '' },
		{ name: 'Code', openWith: '(!(<source lang="[![Language:!:php]!]">|!|<pre>)!)', closeWith: '(!(</source>|!|</pre>)!)' },
		{ separator: '---------------' },
		{ name: 'Preview', call: 'preview', className: 'preview' }
	]
}