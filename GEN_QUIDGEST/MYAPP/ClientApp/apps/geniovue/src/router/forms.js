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
			path: '/:culture/:system/:module/form/MEMBER/:mode/:id?',
			name: 'form-MEMBER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMember/QFormMember.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MEMBER',
				humanKeyFields: ['ValName'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/MEMBER_PSW/:mode/:id?',
			name: 'form-MEMBER_PSW',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMemberPsw/QFormMemberPsw.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MEMBER_PSW',
				humanKeyFields: [],
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
				isPopup: false
			}
		},
	]
}
