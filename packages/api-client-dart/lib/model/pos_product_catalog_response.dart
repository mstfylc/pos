//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/pos_product_category.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_product_catalog_response.g.dart';

abstract class PosProductCatalogResponse implements Built<PosProductCatalogResponse, PosProductCatalogResponseBuilder> {

    @BuiltValueField(wireName: r'categories')
    BuiltList<PosProductCategory> get categories;

    PosProductCatalogResponse._();

    static void _initializeBuilder(PosProductCatalogResponseBuilder b) => b;

    factory PosProductCatalogResponse([void updates(PosProductCatalogResponseBuilder b)]) = _$PosProductCatalogResponse;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosProductCatalogResponse> get serializer => _$PosProductCatalogResponseSerializer();
}

class _$PosProductCatalogResponseSerializer implements StructuredSerializer<PosProductCatalogResponse> {

    @override
    final Iterable<Type> types = const [PosProductCatalogResponse, _$PosProductCatalogResponse];
    @override
    final String wireName = r'PosProductCatalogResponse';

    @override
    Iterable<Object> serialize(Serializers serializers, PosProductCatalogResponse object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'categories')
            ..add(serializers.serialize(object.categories,
                specifiedType: const FullType(BuiltList, [FullType(PosProductCategory)])));
        return result;
    }

    @override
    PosProductCatalogResponse deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosProductCatalogResponseBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'categories':
                    result.categories.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(PosProductCategory)])) as BuiltList<PosProductCategory>);
                    break;
            }
        }
        return result.build();
    }
}

