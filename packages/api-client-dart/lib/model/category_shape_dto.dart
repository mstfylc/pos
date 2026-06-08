//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'category_shape_dto.g.dart';

abstract class CategoryShapeDto implements Built<CategoryShapeDto, CategoryShapeDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'content')
    String get content;

    @BuiltValueField(wireName: r'active')
    bool get active;

    CategoryShapeDto._();

    static void _initializeBuilder(CategoryShapeDtoBuilder b) => b;

    factory CategoryShapeDto([void updates(CategoryShapeDtoBuilder b)]) = _$CategoryShapeDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<CategoryShapeDto> get serializer => _$CategoryShapeDtoSerializer();
}

class _$CategoryShapeDtoSerializer implements StructuredSerializer<CategoryShapeDto> {

    @override
    final Iterable<Type> types = const [CategoryShapeDto, _$CategoryShapeDto];
    @override
    final String wireName = r'CategoryShapeDto';

    @override
    Iterable<Object> serialize(Serializers serializers, CategoryShapeDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'content')
            ..add(serializers.serialize(object.content,
                specifiedType: const FullType(String)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    CategoryShapeDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CategoryShapeDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'content':
                    result.content = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

