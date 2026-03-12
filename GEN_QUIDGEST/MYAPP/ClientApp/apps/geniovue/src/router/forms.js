import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/CATEGORY/:mode/:id?',
			name: 'form-CATEGORY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCategory/QFormCategory.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CATEGORY',
				humanKeyFields: ['ValName'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/CATEGORY_TYPE/:mode/:id?',
			name: 'form-CATEGORY_TYPE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCategoryType/QFormCategoryType.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CATEGORY_TYPE',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/EXPENSE/:mode/:id?',
			name: 'form-EXPENSE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormExpense/QFormExpense.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EXPENSE',
				humanKeyFields: ['ValExpense_id'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/GROUP/:mode/:id?',
			name: 'form-GROUP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGroup/QFormGroup.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GROUP',
				humanKeyFields: ['ValName'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/GROUP_PSW/:mode/:id?',
			name: 'form-GROUP_PSW',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGroupPsw/QFormGroupPsw.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GROUP_PSW',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/INCOME/:mode/:id?',
			name: 'form-INCOME',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormIncome/QFormIncome.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INCOME',
				humanKeyFields: ['ValIncome_id'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/INVESTMENT/:mode/:id?',
			name: 'form-INVESTMENT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormInvestment/QFormInvestment.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INVESTMENT',
				humanKeyFields: ['ValInvestment_id'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/MEMBER/:mode/:id?',
			name: 'form-MEMBER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMember/QFormMember.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MEMBER',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/SOURCE/:mode/:id?',
			name: 'form-SOURCE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormSource/QFormSource.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'SOURCE',
				humanKeyFields: ['ValTitle'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/WD_CATEGORIES/:mode/:id?',
			name: 'form-WD_CATEGORIES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWdCategories/QFormWdCategories.vue'),
			meta: {
				routeType: 'form',
				baseArea: '',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/WD_EXPENSES/:mode/:id?',
			name: 'form-WD_EXPENSES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWdExpenses/QFormWdExpenses.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EXPENSE',
				humanKeyFields: ['ValExpense_id'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/WD_LAST_EXPENSES/:mode/:id?',
			name: 'form-WD_LAST_EXPENSES',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWdLastExpenses/QFormWdLastExpenses.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EXPENSE',
				humanKeyFields: ['ValExpense_id'],
				isPopup: false
			}
		},
	]
}
