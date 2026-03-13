import { createFramework } from '@quidgest/ui/framework'

const framework = createFramework({
	themes: {
		defaultTheme: 'Light',
		themes: [
			{
				name: 'Light',
				mode: 'light',
				colors: {
					background: '',
					primary: '#047857',
					onBackground: '#0F172A',
					secondary: '#0F172A',
					danger: '#EF4444',
					info: '#7C3AED',
					success: '#10B981',
					primaryLight: '#0EA5A4',
					primaryDark: '#065F46',
					highlight: '#14B8A6',
				}
			}
		]
	},
	defaults: {
		QIconSvg: {
			bundle: 'Content/svgbundle.svg?v=115'
		},
		QCollapsible: {
			icons: {
				chevron: {
					icon: 'expand'
				}
			}
		},
		QListItem: {
			icons: {
				check: {
					icon: 'ok'
				},
				description: {
					icon: 'help'
				}
			}
		},
		QSelect: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QCombobox: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QPropertyList: {
			icons: {
				open: {
					icon: 'square-minus',
				},
				close: {
					icon: 'square-plus',
				}
			}
		},
		QCheckbox: {
			icons: {
				checked: {
					icon: 'ok'
				},
				indeterminate: {
					icon: 'minus'
				}
			}
		},
		QCarousel: {
			icons: {
				back: {
					icon: 'step-back'
				},
				forward: {
					icon: 'step-forward'
				}
			}
		}
	}
})

export default framework
