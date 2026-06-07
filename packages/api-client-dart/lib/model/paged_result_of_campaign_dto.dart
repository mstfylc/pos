//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/campaign_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'paged_result_of_campaign_dto.g.dart';

abstract class PagedResultOfCampaignDto implements Built<PagedResultOfCampaignDto, PagedResultOfCampaignDtoBuilder> {

    @BuiltValueField(wireName: r'items')
    BuiltList<CampaignDto> get items;

    @BuiltValueField(wireName: r'page')
    int get page;

    @BuiltValueField(wireName: r'pageSize')
    int get pageSize;

    @BuiltValueField(wireName: r'totalCount')
    int get totalCount;

    @BuiltValueField(wireName: r'totalPages')
    int get totalPages;

    PagedResultOfCampaignDto._();

    static void _initializeBuilder(PagedResultOfCampaignDtoBuilder b) => b;

    factory PagedResultOfCampaignDto([void updates(PagedResultOfCampaignDtoBuilder b)]) = _$PagedResultOfCampaignDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PagedResultOfCampaignDto> get serializer => _$PagedResultOfCampaignDtoSerializer();
}

class _$PagedResultOfCampaignDtoSerializer implements StructuredSerializer<PagedResultOfCampaignDto> {

    @override
    final Iterable<Type> types = const [PagedResultOfCampaignDto, _$PagedResultOfCampaignDto];
    @override
    final String wireName = r'PagedResultOfCampaignDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PagedResultOfCampaignDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'items')
            ..add(serializers.serialize(object.items,
                specifiedType: const FullType(BuiltList, [FullType(CampaignDto)])));
        result
            ..add(r'page')
            ..add(serializers.serialize(object.page,
                specifiedType: const FullType(int)));
        result
            ..add(r'pageSize')
            ..add(serializers.serialize(object.pageSize,
                specifiedType: const FullType(int)));
        result
            ..add(r'totalCount')
            ..add(serializers.serialize(object.totalCount,
                specifiedType: const FullType(int)));
        result
            ..add(r'totalPages')
            ..add(serializers.serialize(object.totalPages,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    PagedResultOfCampaignDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PagedResultOfCampaignDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'items':
                    result.items.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(CampaignDto)])) as BuiltList<CampaignDto>);
                    break;
                case r'page':
                    result.page = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'pageSize':
                    result.pageSize = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'totalCount':
                    result.totalCount = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'totalPages':
                    result.totalPages = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

